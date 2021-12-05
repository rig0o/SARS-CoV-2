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
    }
}
