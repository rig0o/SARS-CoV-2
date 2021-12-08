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
    public partial class VistaPrincipal : Form
    {
        Thread th;
        public VistaPrincipal()
        {
            InitializeComponent();
        }

        private void VistaPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnVistaPrediccion_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openNewform(object obj)
        {
            Application.Run(new VistaPrediccion());
        }
    }
}
