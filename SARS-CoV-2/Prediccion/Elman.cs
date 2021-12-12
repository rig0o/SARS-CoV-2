using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARS_CoV_2.Database.Dto;

namespace SARS_CoV_2.Prediccion
{
    [Serializable]
    public class Elman
    {
        #region Atributos
        public int NumInput { get; set; }
        public int NumHidden { get; set; }
        public int NumOutput { get; set; }
        public double[,] Whx { get; set; }
        public double[,] Whh { get; set; }
        public double[,] Woh { get; set; }
        public double[,] Bh { get; set; }
        public double[,] Bo { get; set; }

        private Dictionary<int, double[,]> ActsInp;       // Inputs          Vector columna
        private Dictionary<int, double[,]> SumsHid;       // Sumatoria Zt    Vector columna
        private Dictionary<int, double[,]> ActsHid;       // Activacion Ht   Vector columna
        private Dictionary<int, double[,]> SumsOut;       // Sumatoria  Yt   Vector columna
        private Dictionary<int, double[,]> ActsOut;       // Activacion Pt   Vector columna
        #endregion

        public Elman(int input, int hidden, int output)
        {
            this.NumInput = input;
            this.NumHidden = hidden;
            this.NumOutput = output;

            Whx = Operaciones.RandomValues(hidden, input);
            Whh = Operaciones.RandomValues(hidden, hidden);
            Woh = Operaciones.RandomValues(output, hidden);

            Bh = Operaciones.RandomValues(hidden, 1);
            Bo = Operaciones.RandomValues(output, 1);
        }
        public Dictionary<int, double[,]> FeedForward(List<DatasetDto> inputs)
        {
            var hiddenAnterior = Operaciones.RandomZeros(NumHidden);

            ActsInp = new Dictionary<int, double[,]>();
            SumsHid = new Dictionary<int, double[,]>(); // Zt 
            ActsHid = new Dictionary<int, double[,]>(); // Ht
            SumsOut = new Dictionary<int, double[,]>(); // Yt
            ActsOut = new Dictionary<int, double[,]>(); // Pt

            ActsHid[-1] = hiddenAnterior;
            for (int t = 0; t < inputs.Count; t++) //  t max 461 2021-11-01
            {
                ActsInp[t] = inputs[t].ToArry(); //Dim Input =  [x,1]

                // Capa oculta
                var fromInput = Operaciones.Mutiply(Whx, ActsInp[t]);    
                var fromHidden = Operaciones.Mutiply(Whh, ActsHid[t - 1]);
                var wxh = Operaciones.Add(fromInput, fromHidden);           

                SumsHid[t] = Operaciones.Add(wxh, Bh);                    // [h,1] Vector columna           
                ActsHid[t] = Operaciones.Sigmoid(SumsHid[t]);             // [h,1] Vector columna                        


                // Capa de salida
                var wxy = Operaciones.Mutiply(Woh, ActsHid[t]);           
                SumsOut[t] = Operaciones.Add(wxy, Bo);                    // [o,1] Vector columna
                ActsOut[t] = Operaciones.Sigmoid(SumsOut[t]);             // [o,1] Vector columna
            }
            return ActsOut;
        }
        #region Entrenamiento
        public bool Train(double alfa, double maxLoss, int maxEpoch, int deep, List<DatasetDto> inputs, List<GraficoDto> target)
        {
            double error = 9999;

            for (int epoch = 0; epoch < maxEpoch; epoch++)
            {
                BPTT(inputs, target, alfa, deep);
                var prediccion = FeedForward(inputs);
                error = MSE(prediccion, target);


                if (error < maxLoss) return true;

                if (epoch % 10000 == 0)
                {
                    //using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
                    //{
                    //    write.WriteLine(DateTime.Now.ToString("HH:mm:ss ") + "  Epoca :" + epoch + " Error = " + error);
                    //}
                }
            }

            //using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
            //{
            //    write.WriteLine(" ");
            //    write.WriteLine("  Minimo Local  :" + error);
            //}
            return false;
        }
        private double MSE(Dictionary<int, double[,]> estimado, List<GraficoDto> target)
        {
            Dictionary<int, double[,]> error = new Dictionary<int, double[,]>();
            double[,] auxError = Operaciones.RandomZeros(NumOutput);

            for (int i = 0; i < estimado.Count; i++)
            {
                error[i] = Operaciones.Pow(Operaciones.Sub(estimado[i], target[i+10].ToArry()), 2);
                auxError = Operaciones.Add(auxError, error[i]);

            }
            return Math.Sqrt(auxError[0, 0] / estimado.Count);
        }
        private void BPTT(List<DatasetDto> inputs, List<GraficoDto> target, double alfa, int depth)
        {
            double[,] dErrdWoh;
            double[,] dErrdBo;
            double[,] dErrdWhh;
            double[,] dErrdWhx;
            double[,] dErrdBh;

            var salida = FeedForward(inputs);

            for (int t = 0; t < inputs.Count; t++)
            {

                var outError = GetOutError(ActsOut[t], target[t+10].ToArry(), SumsOut[t]);

                dErrdWoh = Operaciones.GetOuterVec(outError, ActsHid[t]);
                this.Woh = Update(this.Woh, dErrdWoh, alfa);

                dErrdBo = outError;
                this.Bo = Update(this.Bo, dErrdBo, alfa);

                var hiddenError = GetError(outError, Woh, SumsHid[t]);


                for (int k = 0; k < depth && t - k > 0; k++)
                {

                    dErrdWhh = Operaciones.GetOuterVec(hiddenError, ActsHid[t - k - 1]);
                    this.Whh = Update(this.Whh, dErrdWhh, alfa);

                    dErrdWhx = Operaciones.GetOuterVec(hiddenError, ActsInp[t - k]);
                    this.Whx = Update(this.Whx, dErrdWhx, alfa);

                    dErrdBh = hiddenError;
                    this.Bh = Update(this.Bh, dErrdBh, alfa);
                    
                    hiddenError = GetError(hiddenError, Whh, SumsHid[t - k - 1]);
                }
            }
        }
        private double[,] GetError(double[,] outError, double[,] pesos, double[,] sumHidden)
        {
            var wT = Operaciones.T(pesos);
            var propagated = Operaciones.Mutiply(wT, outError);
            return Operaciones.GetMulElemVec(propagated, Operaciones.DSigmoid(sumHidden));
        }
        private double[,] GetOutError(double[,] salida, double[,] target, double[,] sumOut)
        {
            //[o,1]
            double[,] error = Operaciones.Sub(salida, target);
            return Operaciones.GetMulElemVec(error, Operaciones.DSigmoid(sumOut));

        }
        private double[,] Update(double[,] actualiza, double[,] derivada, double alfa)
        {
            double[,] n = Operaciones.MutiplyEscalar(derivada, alfa);
            return Operaciones.Sub(actualiza, n);
        }
        
        
        
        //private void UpdateWoh(double[,] dErrdOh, double alfa)
        //{
        //    double[,] noh = Operaciones.MutiplyEscalar(dErrdOh, alfa);
        //    Woh = Operaciones.Sub(Woh, noh);
        //}
        //private void UpdateBo(double[,] dErrdBo, double alfa)
        //{
        //    double[,] nbo = Operaciones.MutiplyEscalar(dErrdBo, alfa);
        //    Bo = Operaciones.Sub(Bo, nbo);
        //}
        //private void UpdateWhh(double[,] dErrdWhh, double alfa)
        //{
        //    double[,] nhh = Operaciones.MutiplyEscalar(dErrdWhh, alfa);
        //    Whh = Operaciones.Sub(Whh, nhh);
        //}
        //private void UpdateWhx(double[,] dErrdWhx, double alfa)
        //{
        //    double[,] nhx = Operaciones.MutiplyEscalar(dErrdWhx, alfa);
        //    Whx = Operaciones.Sub(Whx, nhx);
        //}
        //private void UpdateBh(double[,] dErrdBh, double alfa)
        //{
        //    double[,] nbh = Operaciones.MutiplyEscalar(dErrdBh, alfa);
        //    Bh = Operaciones.Sub(Bh, nbh);
        //}
        #endregion

    }
}
