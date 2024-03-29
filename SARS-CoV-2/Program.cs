using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SARS_CoV_2.Vista;
using SARS_CoV_2.Database.Models;
using SARS_CoV_2.Database;
using System.Diagnostics;
using SARS_CoV_2.Prediccion;
using System.IO;

namespace SARS_CoV_2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //DataRepository repo = new DataRepository();
            //var lst = repo.GetDataRealista();
            //var nn = Fit.Load();
            //var salida = nn.FeedForward(lst);

            //for (int i = 0; i < salida.Count; i++)
            //{
            //    salida[i][0, 0] = DataRepository.DesNorm(salida[i][0, 0]);
            //    Debug.WriteLine(salida[i][0, 0]);
            //}

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VistaMenuPrincipal());
        }
    }
}
