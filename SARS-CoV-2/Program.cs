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
            Fit.fit();

            //var rnn = Fit.Load();

            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new VistaPrediccion());


        }
    }
}
