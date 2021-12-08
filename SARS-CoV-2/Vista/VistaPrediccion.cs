using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SARS_CoV_2.Vista
{
    public partial class VistaPrediccion : Form
    {
        Thread th;
        public VistaPrediccion()
        {
            InitializeComponent();

            cartesianChart1.Series = new ObservableCollection<ISeries>
            {
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> { 12, 11, 13, 15,13, 14, 16 },
                    Fill = null
                }
            };
        }

        private void VistaPrediccion_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrenar_Click(object sender, EventArgs e)
        {

        }

        private void btnPredecir_Click(object sender, EventArgs e)
        {
            /*
             defecto 
            */
            //checkedListBox1.Items.Contains(theItemToCheck)

            int s = cklPlanPasoLSCQ.SelectedIndex;
            Debug.WriteLine(s);
            //Console.WriteLine(s);
        }

        private void btnEscenarioModificado_Click(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewform(object obj)
        {
            Application.Run(new VistaPrincipal());
        }

        private void ckBoxLSCQ_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbLaSerenaCoquimbo_Click(object sender, EventArgs e)
        {

        }

        private void cklPlanPasoLSCQ_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklPlanPasoLSCQ.SelectedIndex;
            int count = cklPlanPasoLSCQ.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklPlanPasoLSCQ.SetItemCheckState(i, CheckState.Unchecked);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }
    }
}
