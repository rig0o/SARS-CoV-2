﻿using LiveChartsCore;
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
using SARS_CoV_2.Prediccion;

namespace SARS_CoV_2.Vista
{
    public partial class VistaPrediccion : Form
    {
        Thread th;
        private ObservableCollection<ISeries> predictions;

        public VistaPrediccion()
        {
            InitializeComponent();
            InitCartesianChart();
            
        }
        private void InitCartesianChart()
        {
            DataRepository repo = new DataRepository();
            cartesianChart1.ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X;
            predictions = new ObservableCollection<ISeries>
            {
                new LineSeries<DateTimePoint>
                {
                    Name = "Contagios totales",
                    LineSmoothness = 1,
                    Values = repo.GetDataGraph(),
                    Stroke = new SolidColorPaint(new SKColor(25, 118, 210),2),  // new SKColor(25, 118, 210)  --> AZUL
                    GeometryStroke = new SolidColorPaint(new SKColor(25, 118, 210),2), // AZUL
                    GeometrySize = 3,
                    Fill = null
                }
            };
            cartesianChart1.Series = predictions;
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
                    //MinStep = TimeSpan.FromDays(1).Ticks

                    // if the difference between our points is in hours then we would:
                    // UnitWidth = TimeSpan.FromHours(1).Ticks,

                    // since all the months and years have a different number of days
                    // we can use the average, it would not cause any visible error in the user interface
                    // Months: TimeSpan.FromDays(30.4375).Ticks
                    // Years: TimeSpan.FromDays(365.25).Ticks
                }
            };
            cartesianChart1.YAxes = new List<Axis>
            {
                new Axis
                {
                    Name = "Contagios totales",

                    // Now the Y axis we will display it as currency
                    // LiveCharts provides some common formatters
                    // in this case we are using the currency formatter.
                    Labeler = Labelers.Default

                    // you could also build your own currency formatter
                    // for example:
                    // Labeler = (value) => value.ToString("C")

                    // But the one that LiveCharts provides creates shorter labels when
                    // the amount is in millions or trillions
                }
            };
        }
        private void Grafico_Click(object sender, EventArgs e)
        {

            var pesimista = new LineSeries<DateTimePoint> 
            {
                Name = "pesimista",
                LineSmoothness = 1,
                Values = Fit.casoPesimista(),
                Stroke = new SolidColorPaint(new SKColor(203 ,040, 033), 2),  // ROJO
                GeometryStroke = new SolidColorPaint(new SKColor(203, 040, 033), 2), // ROJO
                GeometrySize = 3,
                Fill = null
            };
            var optimista = new LineSeries<DateTimePoint>
            {
                Name = "Optimista",
                LineSmoothness = 1,
                Values = Fit.casoOptimista(),
                Stroke = new SolidColorPaint(new SKColor(048 ,132 ,070), 2),  // Verde
                GeometryStroke = new SolidColorPaint(new SKColor(048, 132, 070), 2), // Verde
                GeometrySize = 3,
                Fill = null
            };
            var realista = new LineSeries<DateTimePoint>
            {
                Name = "Realista",
                LineSmoothness = 1,
                Values = Fit.casoRealista(),
                Stroke = new SolidColorPaint(new SKColor(25, 118, 210), 2),  // new SKColor(25, 118, 210)  --> AZUL
                GeometryStroke = new SolidColorPaint(new SKColor(25, 118, 210), 2), // AZUL
                GeometrySize = 3,
                Fill = null
            };

            predictions.Add(pesimista);
            predictions.Add(optimista);
            predictions.Add(realista);
            //cartesianChart1.Series = predictions;

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
        // Este no .
        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }

        private void btnModificado_Click(object sender, EventArgs e)
        {
            DataRepository repo = new DataRepository();
            var lst = repo.GetDataRealista();

            int ovalle = cklOvalle.SelectedIndex;
            int conurbacion = cklConurbacion.SelectedIndex;
            int illapel = cklIllapel.SelectedIndex;
            int salamanca = cklSalamanca.SelectedIndex;
            int montepatria = cklMontePatria.SelectedIndex;
            
            int movilidad = cklMovilidad.SelectedIndex;
            int excepcion = cklExcepcion.SelectedIndex;
            int variante = cklVariante.SelectedIndex;
            int vacaciones = cklVacaciones.SelectedIndex;

            if(ovalle != -1){

                switch (ovalle){
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PppOvalle = 0;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PppOvalle = 0.33;
                        }

                        break;

                    case 2:
                        foreach (var item in lst)
                        {
                            item.PppOvalle = 0.66;
                        }

                        break;
                    case 3:
                        foreach (var item in lst)
                        {
                            item.PppOvalle = 1;
                        }

                        break;
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }
                
            }

            if (conurbacion != -1){

                switch (conurbacion)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PppConurbacioLaSerenaCoquimbo = 0;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PppConurbacioLaSerenaCoquimbo = 0.33;
                        }

                        break;

                    case 2:
                        foreach (var item in lst)
                        {
                            item.PppConurbacioLaSerenaCoquimbo = 0.66;
                        }

                        break;
                    case 3:
                        foreach (var item in lst)
                        {
                            item.PppConurbacioLaSerenaCoquimbo = 1;
                        }

                        break;
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }

            }

            if (illapel != -1){
                switch (illapel)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PppIllapel = 0;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PppIllapel = 0.33;
                        }

                        break;

                    case 2:
                        foreach (var item in lst)
                        {
                            item.PppIllapel = 0.66;
                        }

                        break;
                    case 3:
                        foreach (var item in lst)
                        {
                            item.PppIllapel = 1;
                        }

                        break;
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }
            }

            if (salamanca != -1){
                switch (salamanca)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PppSalamanca = 0;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PppSalamanca = 0.33;
                        }

                        break;

                    case 2:
                        foreach (var item in lst)
                        {
                            item.PppSalamanca = 0.66;
                        }

                        break;
                    case 3:
                        foreach (var item in lst)
                        {
                            item.PppSalamanca = 1;
                        }

                        break;
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }
            }

            if (montepatria != -1){
                switch (montepatria)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PppMontePatria = 0;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PppMontePatria = 0.33;
                        }

                        break;

                    case 2:
                        foreach (var item in lst)
                        {
                            item.PppMontePatria = 0.66;
                        }

                        break;
                    case 3:
                        foreach (var item in lst)
                        {
                            item.PppMontePatria = 1;
                        }

                        break;
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }
            }

            if (movilidad != -1){

                // 1 = Si
                // 0 = No
                switch (movilidad)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PaseMovilidad = 1;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PaseMovilidad = 0;
                        }

                        break;
                    
                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }

            }

            if (excepcion != -1){
                switch (excepcion)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.EstadoExcepcion = 1;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.EstadoExcepcion = 0;
                        }

                        break;

                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }

            }

            if (variante != -1){
                switch (variante)
                {
                    case 0: //Alpha
                        foreach (var item in lst)
                        {
                            item.Alpha = 1;
                            item.Gamma = 0;
                            item.Delta = 0;
                            
                        }
                        break;

                    case 1: //Gamma
                        foreach (var item in lst)
                        {
                            item.Alpha = 0;
                            item.Gamma = 1;
                            item.Delta = 0;

                        }

                        break;

                    case 2: //Delta
                        foreach (var item in lst)
                        {
                            item.Alpha = 0;
                            item.Gamma = 0;
                            item.Delta = 1;

                        }

                        break;

                    case 3: //Original
                        foreach (var item in lst)
                        {
                            item.Alpha = 0;
                            item.Gamma = 0;
                            item.Delta = 0;

                        }

                        break;

                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }


            }

            if (vacaciones != -1){
                switch (vacaciones)
                {
                    case 0:
                        foreach (var item in lst)
                        {
                            item.PermisoVacaciones = 1;
                        }
                        break;

                    case 1:
                        foreach (var item in lst)
                        {
                            item.PermisoVacaciones = 0;
                        }

                        break;

                    default:
                        Debug.WriteLine("Error 172");
                        break;
                }
            }


            var pesimista = new LineSeries<DateTimePoint>
            {
                Name = "Modificado",
                LineSmoothness = 1,
                Values = Fit.casoModificado(lst),
                Stroke = new SolidColorPaint(new SKColor(229,190,001), 2),  // Amarillo
                GeometryStroke = new SolidColorPaint(new SKColor(229, 190, 001), 2), // Amarillo
                GeometrySize = 3,
                Fill = null
            };
            predictions.Add(pesimista);


        }


    }
}
