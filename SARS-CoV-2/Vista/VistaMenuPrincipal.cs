﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARS_CoV_2.Vista
{
    public partial class VistaMenuPrincipal : Form
    {
        
        public VistaMenuPrincipal()
        {
            InitializeComponent();
        }

        public void btnPrediccion_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            Thread th;
            th = new Thread(openNewformPrediccion);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

            //VistaPrediccion ventana2 = new VistaPrediccion();
            //ventana2.Show();
        }

        private void btnHistorialContagios_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th;
            th = new Thread(openNewformHistorial);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openNewformHistorial(object obj)
        {
            Application.Run(new VistaHistorialContagios());
        }

        private void openNewformPrediccion(object obj)
        {
            Application.Run(new VistaPrediccion());
        }
    }
}
