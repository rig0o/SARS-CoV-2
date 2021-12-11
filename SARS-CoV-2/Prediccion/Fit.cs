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

            Elman nn = new Elman(26, 13, 1);

                            //ALFA(lr) - Error - Epoca - Deep
            while (!nn.Train(0.025, 0.035, 75000, 7, datax, datay))
            {
                nn = new Elman(26, 13, 1);
            }

            Save(nn);
        }
        public static void Save(Elman nn)
        {
            FileStream fs = new FileStream(rnnPath, FileMode.Create);
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
    }
}
