using Microsoft.VisualStudio.TestTools.UnitTesting;
using SARS_CoV_2.Database;
using SARS_CoV_2.Database.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_SARS_CoV_2
{
    [TestClass]
    public class RepoTest
    {
        [TestMethod]
        public void TestGetDatos()
        {
            DataRepository repo = new();

            List<DatasetDto> data = repo.GetDataTrain();

            Assert.IsNotNull(data);

        }

    }
}
