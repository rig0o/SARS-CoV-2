using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARS_CoV_2.Database;
using SARS_CoV_2.Database.Models;
using SARS_CoV_2.Database.Dto;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_SARS_CoV_2
{
    [TestClass]
    public class RepoTest
    {
        [TestMethod]
        public void GetConexion()
        {
            using (var context = new datasetContext())
            {
                var conn = context.Database;
                Assert.IsTrue(conn.CanConnect());
            }
        }
        [TestMethod]
        public void TestGetDatosTrain()
        {
            DataRepository repo = new();

            List<DatasetDto> data = repo.GetDataTrain();

            foreach (var item in data)
            {
                Assert.IsNotNull(item);
            }
        }
        [TestMethod]
        public void TestGetDatosTarget()
        {
            DataRepository repo = new();

            List<GraficoDto> data = repo.GetDataTarget();

            foreach (var item in data)
            {
                Assert.IsNotNull(item);
            }
        }
        [TestMethod]
        public void TestGetDatosRealista()
        {
            DataRepository repo = new();

            List<DatasetDto> data = repo.GetDataRealista();

            foreach (var item in data)
            {
                Assert.IsNotNull(item);
            }
            Assert.AreEqual(data.Count, 10);
        }
        [TestMethod]
        public void TestGetDatosPesimista()
        {
            DataRepository repo = new();

            List<DatasetDto> data = repo.GetDataPesimista();
            List<DatasetDto> real = repo.GetDataRealista();

            foreach (var item in data)
            {
                Assert.IsNotNull(item);
            }
            for (int i = 0; i < real.Count; i++)
            {
                Assert.AreNotEqual(data[i], real[i]);
            }
            Assert.AreEqual(data.Count, 10);
        }
        [TestMethod]
        public void TestGetDatosOptimista()
        {
            DataRepository repo = new();

            List<DatasetDto> data = repo.GetDataOptimista();
            List<DatasetDto> real = repo.GetDataRealista();

            foreach (var item in data)
            {
                Assert.IsNotNull(item);
            }
            for (int i = 0; i < real.Count; i++)
            {
                Assert.AreNotEqual(data[i],real[i]);
            }
            Assert.AreEqual(data.Count, 10);
        }
        [TestMethod]
        public void TestDesNormalizar()
        {
            double x1 = 4;
            double x2 = 131;
            double x3 = 258;
            double x4 = 385;

            var x1t = DataRepository.DesNorm(0);
            var x2t = DataRepository.DesNorm(0.333333);
            var x3t = DataRepository.DesNorm(0.666666);
            var x4t = DataRepository.DesNorm(1);
            
            Assert.AreEqual(x1,x1t);
            Assert.AreEqual(x2, x2t);
            Assert.AreEqual(x3, x3t);
            Assert.AreEqual(x4, x4t);
        }
    }
}
