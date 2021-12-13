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
using SARS_CoV_2.Database;

namespace SARS_CoV_2.Vista
{
    public partial class VistaHistorialContagios : Form
    {
        public VistaHistorialContagios()
        {
            InitializeComponent();
            InitDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Thread th;
            th = new Thread(openNewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewform(object obj)
        {
            Application.Run(new VistaMenuPrincipal());
        }

        private void InitDatos()
        {
            var repo = new DataRepository();
            var lista = repo.GetDataGraph();

            for (int i = 0; i < lista.Count; i++)
            {
                DataGridViewRow fila = new DataGridViewRow();
                fila.CreateCells(dataGridView1);
                fila.Cells[0].Value = lista[i].DateTime.ToString("dd/MMMM/yyyy");
                fila.Cells[1].Value = lista[i].Value;
                dataGridView1.Rows.Add(fila);
            } 
        }
    }
}
