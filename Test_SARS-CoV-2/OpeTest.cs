using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SARS_CoV_2.Prediccion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_SARS_CoV_2
{
    [TestClass]
    public class OpeTest
    {
        [TestMethod]
        public void Suma_matriz()
        {
            double[,] a = { { 1, 1 }, { 2, 2 } };
            double[,] b = { { 2, 2 }, { 3, 3 } };

            double[,] esperado = { { 3, 3 }, { 5, 5 } };
            double[,] res = Operaciones.Add(a, b);

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], res[i, j]);
                }
            }
        }
        [TestMethod]
        public void Crear_Matriz_random()
        {
            double[,] res1 = Operaciones.RandomValues(2, 2);
            double[,] res2 = Operaciones.RandomValues(2, 2);

            Assert.IsNotNull(res1);

            Assert.IsInstanceOfType(res1, typeof(double[,]));

            Assert.AreNotEqual<double[,]>(res1, res2);
            for (int i = 0; i < res1.GetLength(0); i++)
            {
                for (int j = 0; j < res1.GetLength(1); j++)
                {
                    Assert.AreNotEqual(res1[i, j], res2[i, j]);
                }
            }
        }
        [TestMethod]
        public void Crear_matriz_zeros()
        {
            double[,] res = Operaciones.RandomZeros(2, 2);

            Assert.IsNotNull(Operaciones.RandomZeros(2, 2));

            for (int i = 0; i < res.GetLength(0); i++)
            {
                for (int j = 0; j < res.GetLength(1); j++)
                {
                    Assert.AreEqual(res[i, j], 0);
                }
            }
        }
        [TestMethod]
        public void Multiplicar_matriz()
        {

            double[,] m = { { 1, 1 }, { 2, 2 } };
            double[,] n = { { 2, 2 }, { 3, 3 } };

            double[,] esperado = { { 5, 5 }, { 10, 10 } };

            double[,] res = Operaciones.Mutiply(m, n);

            for (int i = 0; i < m.GetLength(0); i++)
            {
                for (int j = 0; j < m.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], res[i, j]);
                }
            }

        }
        [TestMethod]
        public void Tanh_valor()
        {
            double[,] a = { { 1000, 0.7 }, { 0.3, 0.1 } };

            double[,] salida = Operaciones.Tanh(a);
            Operaciones.Imprime(salida);

            double[,] esperado = { { 1, .6043677771171634 }, { .2913126124515908, .0996679946249559 } };

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], salida[i, j]);
                }
            }
        }
        [TestMethod]
        public void Rangos_Tanh()
        {
            double[,] a = { { 1000, -1000 } };
            double[,] res = Operaciones.Tanh(a);

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Assert.IsTrue(res[i, j] <= 1 && res[i, j] >= -1);
                }
            }


        }
        [TestMethod]
        public void Dtanh_valor()
        {
            double[,] input = { { 1000, -1000 }, { 0.3, 0.1 } };

            double[,] salida = Operaciones.DTanh(input);


            double[,] esperado = { { 0, 0 }, { .9151369618266293, .9900662908474398 } };

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], salida[i, j]);
                }
            }
        }
        [TestMethod]
        public void Sigmoid_valores()
        {
            double[,] input = { { 1 }, { 0.2 }, { 0.3 } };

            double[,] salida = Operaciones.Sigmoid(input);

            Operaciones.Imprime(salida);

            double[,] esperado = { { 0.7310585786300049 }, { 0.549833997312478 }, { 0.574442516811659 } };

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], salida[i, j]);
                }
            }


        }
        [TestMethod]
        public void Rango_Sigmoid()
        {

            double[,] a = { { 100, -100 } };
            double[,] res = Operaciones.Sigmoid(a);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Assert.IsTrue(res[i, j] <= 1 && res[i, j] >= 0);
                }
            }

        }
        [TestMethod]
        public void Dsigmoid_valores()
        {
            double[,] input = { { 100, -100 }, { 0.2, 0.8 } };

            double[,] salida = Operaciones.DSigmoid(input);


            double[,] esperado = { { 0, 3.7200759760208356E-44 }, { 0.24751657271185995, 0.2139096965202944 } };

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Assert.AreEqual(esperado[i, j], salida[i, j]);
                }
            }


        }
    }
}
