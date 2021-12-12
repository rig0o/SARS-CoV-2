using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARS_CoV_2.Database.Dto;
using SARS_CoV_2.Database;
using LiveChartsCore.Defaults;

namespace SARS_CoV_2.Prediccion
{
    public class Fit
    {
        private readonly static string rnnPath = Directory.GetCurrentDirectory().ToString() + @"\EntrenamientoElman.bin";
        public static void fit()
        {
            DataRepository repo = new DataRepository();
            List<DatasetDto> datax = repo.GetDataTrain();
            List<GraficoDto> datay = repo.GetDataTarget();

            var lst = repo.GetDataRealista();

            Elman nn = new Elman(26, 13, 1);

            //ALFA(lr) - Error - Epoca - Deep
            while (!nn.Train(0.025, 0.025, 100000, 5, datax, datay))
            {

                var salida = nn.FeedForward(lst);
                using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
                {
                    write.WriteLine("lr - eror - epocas - deep: 0.05, 0.02, 30000, 5");
                    write.WriteLine("  hora :" + DateTime.Now.ToString("HH:mm:ss"));
                    write.WriteLine("");
                    write.Write("Prediccion: ");
                }
                for (int i = 0; i < salida.Count; i++)
                {
                    using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
                    {
                        write.Write(DataRepository.DesNorm(salida[i][0, 0]) + "  ");
                    }
                }
                using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
                {
                    write.WriteLine("");
                    write.Write("Esperador:  ");
                    write.WriteLine("95  123  81 80  76  85 110  131 89  108  ");
                    write.WriteLine("");
                    write.WriteLine("  Se procede a reinicar el entrenamiento");
                    write.WriteLine("  Se procede a reinicar el entrenamiento");
                    write.WriteLine("----------------------------------------------");
                    write.WriteLine(""); write.WriteLine(""); write.WriteLine(""); write.WriteLine("");
                }

                Save(nn);
                nn = new Elman(26, 13, 1);
            }

            var salida1 = nn.FeedForward(lst);
            using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
            {
                write.WriteLine("  hora :" + DateTime.Now.ToString("HH-mm-ss"));
                write.WriteLine("");
                write.Write("Prediccion: ");
            }
            for (int i = 0; i < salida1.Count; i++)
            {
                using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
                {
                    write.Write(DataRepository.DesNorm(salida1[i][0, 0]) + "  ");
                }
            }
            using (StreamWriter write = new StreamWriter(Directory.GetCurrentDirectory().ToString() + @"\0Entrenamientos\LogError.txt", true))
            {
                write.WriteLine("");
                write.Write("Esperador:  ");
                write.WriteLine("95  123  81 80 76  85 110  131 89  108  ");
                write.WriteLine("");
                write.WriteLine("  Se procede a reinicar el entrenamiento");
                write.WriteLine("  Se procede a reinicar el entrenamiento");
                write.WriteLine("----------------------------------------------");
                write.WriteLine(""); write.WriteLine(""); write.WriteLine(""); write.WriteLine("");
            }
            
            Save(nn);
        }
        public static void Save(Elman nn)
        {
            string name = @"0Entrenamientos\EntrenamientoElman-" + DateTime.Now.ToString("HH-mm-ss") + ".bin";
            FileStream fs = new FileStream(name, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, nn);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("No se puede guardar la red, motivo: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        public static Elman Load()
        {
            FileStream fs = new FileStream(rnnPath, FileMode.Open);
            Elman nn;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                nn = (Elman)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Error en la carga de la red, motivo :" + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
            return nn;
        }

        public static List<DateTimePoint> casoPesimista()
        {
            DataRepository repo = new DataRepository();
            var lst = repo.GetDataPesimista();
            var nn = Load();
            var salida = nn.FeedForward(lst);
            return repo.GetDataGraphCasos(salida);
        }
        public static List<DateTimePoint> casoOptimista()
        {
            DataRepository repo = new DataRepository();
            var lst = repo.GetDataOptimista();
            var nn = Load();
            var salida = nn.FeedForward(lst);
            return repo.GetDataGraphCasos(salida);
        }
        public static List<DateTimePoint> casoRealista()
        {
            DataRepository repo = new DataRepository();
            var lst = repo.GetDataRealista();
            var nn = Load();
            var salida = nn.FeedForward(lst);
            return repo.GetDataGraphCasos(salida);
        }
    }
}
