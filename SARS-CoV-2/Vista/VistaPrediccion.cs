using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SARS_CoV_2.Database;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;

namespace SARS_CoV_2.Vista
{
    public partial class VistaPrediccion : Form
    {
        Thread th;
        public VistaPrediccion()
        {
            InitializeComponent();
            InitCartesianChart();
        }

        private void InitCartesianChart()
        {
            DataRepository repo = new();
            cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
            //cartesianChart1.LegendPosition = LegendPosition.Right;
            cartesianChart1.Series = new ObservableCollection<ISeries>
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Contagios totales",
                    LineSmoothness = 1,
                    Values = repo.GetDataGraph(),
                    Stroke = new SolidColorPaint(new SKColor(25, 118, 210), 2),  // new SKColor(25, 118, 210)  --> AZUL
                    GeometryStroke = new SolidColorPaint(new SKColor(25, 118, 210), 2), // AZUL
                    GeometrySize = 0,
                    Fill = null
                }
            };
            cartesianChart1.XAxes = new List<Axis>
            {
                new Axis
                {
                    Labeler = value => new DateTime((long)value).ToString("dd/ MMMM /yyyy"),
                    LabelsRotation = 15,

                    // in this case we want our columns with a width of 1 day, we can get that number
                    // using the following syntax
                    UnitWidth = TimeSpan.FromDays(1).Ticks,

                    // The MinStep property forces the separator to be greater than 1 day.
                    MinStep = TimeSpan.FromDays(1).Ticks

                    // if the difference between our points is in hours then we would:
                    // UnitWidth = TimeSpan.FromHours(1).Ticks,

                    // since all the months and years have a different number of days
                    // we can use the average, it would not cause any visible error in the user interface
                    // Months: TimeSpan.FromDays(30.4375).Ticks
                    // Years: TimeSpan.FromDays(365.25).Ticks
                }
            };
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

        private void btnVolver_Click(object sender, EventArgs e)
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

        private void cklConurbacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklConurbacion.SelectedIndex;
            int count = cklConurbacion.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklConurbacion.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklOvalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklOvalle.SelectedIndex;
            int count = cklOvalle.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklOvalle.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklIllapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklIllapel.SelectedIndex;
            int count = cklIllapel.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklIllapel.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklSalamanca_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklSalamanca.SelectedIndex;
            int count = cklSalamanca.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklSalamanca.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklMontePatria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklMontePatria.SelectedIndex;
            int count = cklMontePatria.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklMontePatria.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklMovilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklMovilidad.SelectedIndex;
            int count = cklMovilidad.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklMovilidad.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklExcepcion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklExcepcion.SelectedIndex;
            int count = cklExcepcion.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklExcepcion.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklVariante_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklVariante.SelectedIndex;
            int count = cklVariante.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklVariante.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cklVacaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cklVacaciones.SelectedIndex;
            int count = cklVacaciones.Items.Count;

            for (int i = 0; i < count; i++)
            {
                cklVacaciones.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }

    }
}
