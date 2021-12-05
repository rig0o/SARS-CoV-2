using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARS_CoV_2.Prediccion
{
    public class Operaciones
    {

        #region Crear matrices o vectores
        public static double[,] RandomValues(int x, int y)
        {
            double[,] randomValues = new double[x, y];
            Random r = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    randomValues[i, j] = (r.NextDouble() * 2 - 1);
                }
            }
            return randomValues;
        }
        public static double[,] RandomZeros(int x, int y = 1)
        {
            double[,] zeros = new double[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    zeros[i, j] = 0;
                }
            }
            return zeros;
        }
        #endregion

        #region Operaciones matriciales
        public static double[,] Mutiply(double[,] a, double[,] b)
        {
            // Si matriz A = m*r  y B= r*n  el producto es C=m*n
            if (a.GetLength(1) == b.GetLength(0))
            {
                int m = a.GetLength(0);
                int n = b.GetLength(1);
                int r = a.GetLength(1); // r
                double[,] z = new double[m, n];

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < r; k++)
                        {
                            z[i, j] += a[i, k] * b[k, j];
                        }
                    }
                }
                return z;
            }
            else
            {
                Console.WriteLine("Error, dimensión de matriz");
                return null;
            }
        }
        public static double[,] GetMulElemVec(double[,] error, double[,] activacion)
        {
            double[,] output = new double[activacion.GetLength(0), 1];

            for (int i = 0; i < error.GetLength(0); i++)
            {
                output[i, 0] = error[i, 0] * activacion[i, 0];
            }

            return output;
        }
        public static double[,] T(double[,] x)
        {
            int r = x.GetLength(0);
            int c = x.GetLength(1);
            double[,] output = new double[c, r];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    output[j, i] = x[i, j];
                }
            }

            return output;
        }
        public static double[,] Add(double[,] x, double[,] y)
        {
            int a = x.GetLength(0);
            int b = x.GetLength(1);
            double[,] z = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    try
                    {
                        z[i, j] = x[i, j] + y[i, j];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: Add matriz " + ex.Message);
                    }
                }
            }
            return z;
        }
        public static double[,] Sub(double[,] woh, double[,] noh)
        {
            int row = woh.GetLength(0);
            int col = woh.GetLength(1);

            if (row == noh.GetLength(0) && col == noh.GetLength(1))
            {
                double[,] output = new double[row, col];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        output[i, j] = woh[i, j] - noh[i, j];
                    }
                }

                return output;
            }
            else
            {
                Console.WriteLine("Error, dimensión de matriz  N10");
                return null;
            }
        }
        public static double[,] Tranpuesta_t(double[,] x, int t)
        {
            double[,] z = new double[x.GetLength(1), 1];
            for (int i = 0; i < x.GetLength(1); i++)
            {
                z[i, 0] = x[t, i];
            }
            return z;
        }
        public static double[,] MutiplyEscalar(double[,] dErrdOh, double alfa)
        {
            int row = dErrdOh.GetLength(0);
            int col = dErrdOh.GetLength(1);
            double[,] output = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    output[i, j] = dErrdOh[i, j] * alfa;
                }
            }

            return output;
        }
        internal static double[,] Pow(double[,] x, int e)
        {
            double[,] z = new double[x.GetLength(0), x.GetLength(1)];

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    z[i, j] = Math.Pow(x[i, j], e);
                }
            }
            return z;
        }
        public static double[,] GetOuterVec(double[,] outError, double[,] activacion)
        {
            int row = outError.GetLength(0);
            int col = activacion.GetLength(0);

            var activaciont = T(activacion);

            double[,] output = new double[row, col];

            output = Mutiply(outError, activaciont);


            return output;
        }
        #endregion

        #region Funciones de activación
        private static double Tanh(double v)
        {
            return 2 / (1 + Math.Pow(Math.E, -(2 * v))) - 1;
        }
        public static double[,] Tanh(double[,] x)
        {
            var a = x.GetLength(0);
            var b = x.GetLength(1);
            double[,] z = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    try
                    {
                        z[i, j] = Tanh(x[i, j]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

            return z;
        }
        public static double[,] DTanh(double[,] x)
        {
            var row = x.GetLength(0);
            var col = x.GetLength(1);
            double[,] output = new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    try
                    {
                        output[i, j] = 1 - Math.Pow(Tanh(x[i, j]), 2);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }

            }

            return output;
        }
        private static double Sigmoid(double v)
        {
            return 1.0 / (1 + Math.Exp(-v));
        }
        public static double[,] Sigmoid(double[,] x)
        {
            int a = x.GetLength(0);
            int b = x.GetLength(1);
            double[,] y = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    try
                    {
                        y[i, j] = Sigmoid(x[i, j]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            return y;
        }
        public static double[,] DSigmoid(double[,] x)
        {
            int a = x.GetLength(0);
            int b = x.GetLength(1);
            double[,] y = new double[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    try
                    {
                        y[i, j] = Sigmoid(x[i, j]) * (1 - Sigmoid(x[i, j]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            return y;
        }
        #endregion

        #region Funcion random
        public static void Imprime(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        #endregion
    }
}
