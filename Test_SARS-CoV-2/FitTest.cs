using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SARS_CoV_2.Prediccion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_SARS_CoV_2
{
    [TestClass]
    public class FitTest
    {
        [TestMethod]
        public void testSaveFile()
        {

            Elman nn = new(26, 13, 1);
            Fit.Save(nn);
            string path = Directory.GetCurrentDirectory().ToString() + @"\EntrenamientoElman.bin";
            bool resultado = File.Exists(path);
            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void testLoadFile()
        {
            Elman nn = new(26, 13, 1);
            Fit.Save(nn);

            Elman nnLoad = Fit.Load();
            Assert.IsInstanceOfType(nn, typeof(Elman));

            Assert.AreEqual(nn.NumInput, nnLoad.NumInput);
            Assert.AreEqual(nn.NumHidden, nnLoad.NumHidden);
            Assert.AreEqual(nn.NumOutput, nnLoad.NumOutput);

        }
    }
}
