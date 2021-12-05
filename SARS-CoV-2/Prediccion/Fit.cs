using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARS_CoV_2.Prediccion
{
    class Fit
    {
        static string rnnPath = Directory.GetCurrentDirectory().ToString() + @"\EntrenamientoElman.bin";
        static public void fit()
        {

            List<double[,]> datax;
            List<double[,]> datay;
            Elman nn = new Elman(4, 6, 4);
            /*
            while (!red.Train(0.09,0.01,1000,10,datax, datay)) 
            {
                
            }
            */
            save(nn);
        }
        static public void save(Elman nn)
        {
            FileStream fs = new FileStream(rnnPath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, nn);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("No se pudo serializar, motivo: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }
        static public Elman load()
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
                Console.WriteLine("Error en deserializacion, motivo :" + e.Message);
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
