using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARS_CoV_2.Prediccion;
using SARS_CoV_2.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARS_CoV_2.Database.Dto;
using System.Diagnostics;

namespace Test_SARS_CoV_2
{
    [TestClass]
    public class ElmanTest
    {
        [TestMethod]
        public void crear_red()
        {
            Elman nn = new Elman(2, 2, 1);
            Assert.IsInstanceOfType(nn, typeof(Elman));
            Assert.IsTrue(nn.NumInput == 2 &&
                nn.NumHidden == 2 && nn.NumOutput == 1);
            Assert.IsTrue(nn.Whh != null && nn.Woh != null
                && nn.Whx != null && nn.Bo != null && nn.Bh != null);
        }

        [TestMethod]
        public void FeedForward()
        {
            DataRepository repo = new DataRepository();
            List<DatasetDto> input = repo.GetDataRealista();

            Elman rnn = new Elman(26, 13, 1);

            int tiempo_esperadas = input.Count;
            int Salidas_CapaSalida = rnn.NumOutput;

            Dictionary<int, double[,]> salida = rnn.FeedForward(input);

            Assert.IsInstanceOfType(salida, typeof(Dictionary<int, double[,]>));
            Assert.IsNotNull(salida);

            Assert.AreEqual(tiempo_esperadas, salida.Count);
            Assert.AreEqual(Salidas_CapaSalida, salida[0].GetLength(0));



        }

        [TestMethod]
        public void testTrain()
        {
            Elman nn = new(26, 13, 1);
            DataRepository repo = new DataRepository();
            List<DatasetDto> input = repo.GetDataRealista();
            List<GraficoDto> output = repo.GetDataTarget();

            var t = nn.Train(0.025, 0.9, 1000, 5, input, output);
            Console.WriteLine(t);
            Assert.IsTrue(t);
        }

        [TestMethod]
        public void testTrainError()
        {
            Elman nn = new(26, 13, 1);
            DataRepository repo = new DataRepository();
            List<DatasetDto> input = repo.GetDataRealista();
            List<GraficoDto> output = repo.GetDataTarget();

            var t = nn.Train(0.025, 0.00002, 100, 5, input, output);
            Console.WriteLine(t);

            Assert.IsFalse(t);
        }
    }
}
