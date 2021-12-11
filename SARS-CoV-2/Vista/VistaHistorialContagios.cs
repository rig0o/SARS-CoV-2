using System;
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
    public partial class VistaHistorialContagios : Form
    {
        Thread th;
        public VistaHistorialContagios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewform(object obj)
        {
            Application.Run(new VistaMenuPrincipal());
        }
    }
}
