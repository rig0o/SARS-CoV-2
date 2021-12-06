using System;
using System.Collections.Generic;
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
        private Dictionary<int, double[,]> SumsHid;       // Sumatoria Zt  Vector columna
        private Dictionary<int, double[,]> ActsHid;       // Activacion Ht   Vector columna
        private Dictionary<int, double[,]> SumsOut;       // Sumatoria  Yt   Vector columna
        private Dictionary<int, double[,]> ActsOut;       // Activacion Pt      Vector columna
        #endregion

        public Elman(int input, int hidden, int output)
        {
            this.NumInput = input;
            this.NumHidden = hidden;
            this.NumOutput = output;

            Operaciones init = new Operaciones();

            Whx = Operaciones.RandomValues(hidden, input);
            Whh = Operaciones.RandomValues(hidden, hidden);
            Woh = Operaciones.RandomValues(output, hidden);

            Bh = Operaciones.RandomValues(hidden, 1);
            Bo = Operaciones.RandomValues(output, 1);
        }

        public Dictionary<int, double[,]> FeedForward(List<DatasetDto> inputs)
        {

            var hiddenAnterior = Operaciones.RandomZeros(Bh.GetLength(0), 1);

            ActsInp = new Dictionary<int, double[,]>();
            SumsHid = new Dictionary<int, double[,]>(); // Zt 
            ActsHid = new Dictionary<int, double[,]>(); // Ht
            SumsOut = new Dictionary<int, double[,]>(); // Yt
            ActsOut = new Dictionary<int, double[,]>(); // Pt

            ActsHid[-1] = hiddenAnterior;
            for (int t = 0; t < inputs.Count; t++)  // TIME = t
            {
                //ActsInp[t] = Operaciones.Tranpuesta_t(inputs, t);  //Dim Input =  [x,1]
                ActsInp[t] = inputs[t].ToArry(); //Dim Input =  [x,1]

                // Capa oculta
                var fromInput = Operaciones.Mutiply(Whx, ActsInp[t]);          //Dim fromInput [h,1] Vector columna
                var fromHidden = Operaciones.Mutiply(Whh, ActsHid[t - 1]);     //Dim fromHidden[h,1] Vector columna 
                var wxh = Operaciones.Add(fromInput, fromHidden);             //Dim [h,1] =  Vector columna

                SumsHid[t] = Operaciones.Add(wxh, Bh);                          // Dim [h,1] Vector columna                         
                ActsHid[t] = Operaciones.Sigmoid(SumsHid[t]);                  // Dim [h,1] = A([h,1])    Vector columna                     


                // Capa de salida
                var wxy = Operaciones.Mutiply(Woh, ActsHid[t]);           // Dim  [o,1]   Vector columna
                SumsOut[t] = Operaciones.Add(wxy, Bo);                    // Dim  [o,1]   Vector columna
                ActsOut[t] = Operaciones.Sigmoid(SumsOut[t]);             // Dim  [o,1] = A([o,1])  Vector columna
            }
            return ActsOut;
        }

        #region Entrenamiento
        public bool Train(double alfa, double maxLoss, int numEpoch, int sequalLength, List<DatasetDto> inputs, Dictionary<int, double[,]> target)
        {
            double error = 9999;

            while (error > maxLoss)
            {
                numEpoch--;
                if (numEpoch <= 0)
                {
                    Console.WriteLine("---------------------Minimo local-------------------------");
                    Console.WriteLine(error);
                    return false;
                }

                BPTT(inputs, target, alfa, sequalLength);
                Dictionary<int, double[,]> estimado = FeedForward(inputs);
                error = mse(estimado, target, inputs.Count);

                Console.WriteLine("-------------------------------------------" + numEpoch);
                Console.WriteLine(" Error = " + error);


            }
            return true;
        }
        private double mse(Dictionary<int, double[,]> estimado, Dictionary<int, double[,]> target, int cantidad)
        {
            Dictionary<int, double[,]> error = new Dictionary<int, double[,]>();
            double[,] aux = Operaciones.RandomZeros(estimado[0].GetLength(0));

            for (int i = 0; i < cantidad; i++)
            {
                error[i] = Operaciones.Pow(Operaciones.Sub(estimado[i], target[i]), 2);
                aux = Operaciones.Add(aux, error[i]);

            }
            return aux[0, 0] / cantidad;
        }
        private void BPTT(List<DatasetDto> inputs, Dictionary<int, double[,]> target, double alfa, int depth)
        {

            _ = FeedForward(inputs);

            double[,] dErrdWoh = Operaciones.RandomZeros(NumOutput, NumHidden);
            double[,] dErrdBo = Operaciones.RandomZeros(NumOutput); //Vector columna


            double[,] dErrdWhh = Operaciones.RandomZeros(NumHidden, NumHidden);
            double[,] dErrdWhx = Operaciones.RandomZeros(NumHidden, NumInput);
            double[,] dErrdBh = Operaciones.RandomZeros(NumHidden); // Vector columna

            for (int t = 0; t < inputs.Count; t++)
            {

                // Vector columna [o,1] dError/dAct_salida * dAct_salida/dSum_salida
                var outError = GetOutError(ActsOut[t], target[t], SumsOut[t]);

                //(dError/dSum_Salida) * (dSum_Salida/dWoh)   [o,1] * [h,1]      [o,1]*[1,h]= [o,h]
                dErrdWoh = Operaciones.GetOuterVec(outError, ActsHid[t]);

                //(dError/dSum_Salida) * (dSum_Salida/dBo)
                // [O,1] = [O,1]
                dErrdBo = outError;

                // dSum_hidden/dAct_hidden * dAct_hidden/dSum_hidden
                // [h,1]  Vector columna
                var hiddenError = GetError(outError, Woh, SumsHid[t]);


                for (int k = 0; k < depth && t - k > 0; k++)
                {
                    // Ultima derivada  dSum_hidden_k/ dPesosWhh  - Cuando Ht toma t = -1, la derivada se hace 0.

                    // [h,h]
                    dErrdWhh = Operaciones.Add(dErrdWhh, Operaciones.GetOuterVec(hiddenError, ActsHid[t - k - 1]));


                    //  [h,x]
                    dErrdWhx = Operaciones.Add(dErrdWhx, Operaciones.GetOuterVec(hiddenError, ActsInp[t - k]));

                    // dSumatoria_hidden/dBias_hidden    [1,1] +[1,1]
                    dErrdBh = Operaciones.Add(dErrdBh, hiddenError);

                    // dError/dSum_hidden  dSum_hidden/dSum_hidden()
                    // [h,1]
                    hiddenError = GetError(hiddenError, Whh, SumsHid[t - k - 1]);
                }
                UpdateWoh(dErrdWoh, alfa);
                UpdateBo(dErrdBo, alfa);

                if (t > 0)
                {
                    UpdateWhh(dErrdWhh, alfa);
                    UpdateWhx(dErrdWhx, alfa);
                    UpdateBh(dErrdBh, alfa);
                }
            }
        }
        private double[,] GetError(double[,] outError, double[,] pesos, double[,] sumHidden)
        {
            var wT = Operaciones.T(pesos);
            // [h,1]=[h,o]*[o,1]  Caso capa salida
            // [h,1]=[h,h]*[h,1]  Caso capa oculta
            var propagated = Operaciones.Mutiply(wT, outError);
            // [h,1]*[h,1]  Multiplicacion de cada elemento
            return Operaciones.GetMulElemVec(propagated, Operaciones.DSigmoid(sumHidden));
        }
        private double[,] GetOutError(double[,] salida, double[,] target, double[,] sumOut)
        {
            //[o,1]
            double[,] error = Operaciones.Sub(salida, target);
            // Retorna vector columna de la multiplicacion de dos vectores columnas
            return Operaciones.GetMulElemVec(error, Operaciones.DSigmoid(sumOut));

        }
        private void UpdateWoh(double[,] dErrdOh, double alfa)
        {
            double[,] noh = Operaciones.MutiplyEscalar(dErrdOh, alfa);
            Woh = Operaciones.Sub(Woh, noh);
        }
        private void UpdateBo(double[,] dErrdBo, double alfa)
        {
            double[,] nbo = Operaciones.MutiplyEscalar(dErrdBo, alfa);
            Bo = Operaciones.Sub(Bo, nbo);
        }
        private void UpdateWhh(double[,] dErrdWhh, double alfa)
        {
            double[,] nhh = Operaciones.MutiplyEscalar(dErrdWhh, alfa);
            Whh = Operaciones.Sub(Whh, nhh);
        }
        private void UpdateWhx(double[,] dErrdWhx, double alfa)
        {
            double[,] nhx = Operaciones.MutiplyEscalar(dErrdWhx, alfa);
            Whx = Operaciones.Sub(Whx, nhx);
        }
        private void UpdateBh(double[,] dErrdBh, double alfa)
        {
            double[,] nbh = Operaciones.MutiplyEscalar(dErrdBh, alfa);
            Bh = Operaciones.Sub(Bh, nbh);
        }
        #endregion

    }
}
