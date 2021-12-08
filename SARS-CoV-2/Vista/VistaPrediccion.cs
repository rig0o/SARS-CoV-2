using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARS_CoV_2.Vista
{
    public partial class VistaPrediccion : Form
    {
        public VistaPrediccion()
        {
            InitializeComponent();
        }

        private void Grafico_Click(object sender, EventArgs e)
        {
            cartesianChart1.Series = new ObservableCollection<ISeries>
            {
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> { 12, 11, 13, 19, 23, 27, 30 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> { 2, 1, 3, 5, 3, 4, 6 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> {20, 25, 30, 45, 55, 60, 80 },
                    Fill = null
                },
                new LineSeries<double>
                {
                    Values = new ObservableCollection<double> { 7, 8, 9, 10, 11, 15, 20 },
                    Fill = null
                }
            };
        }
    }
}
