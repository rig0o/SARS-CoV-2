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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARS_CoV_2.Vista
{
    public partial class VistaPrediccion : Form
    {
        //var blue = new SKColor(25, 118, 210);
        //var red = new SKColor(229, 57, 53);
        //var yellow = new SKColor(198, 167, 0);

        public VistaPrediccion()
        {
            InitializeComponent();

            cartesianChart1.Series = new ObservableCollection<ISeries>
            {
                new LineSeries<double>
                {
                    LineSmoothness = 1,
                    Name = "Curva de contigios",
                    Values = new ObservableCollection<double> { 14, 13, 14, 15, 17 },
                    Stroke = new SolidColorPaint(new SKColor(25, 118, 210), 2),
                    GeometryStroke = new SolidColorPaint(new SKColor(25, 118, 210), 2),
                    Fill = null,
                    ScalesYAt = 0 // it will be scaled at the Axis[0] instance
                }
            };

            cartesianChart1.YAxes = new List<Axis>
            {
                new Axis
                {
                    Name = "Contagios Diarios",
                    LabelsPaint = new SolidColorPaint(new SKColor(25, 118, 210))
                }
            };

            //cartesianChart1.Location = new System.Drawing.Point(0, 0);

            //cartesianChart1.Size = new System.Drawing.Size(150, 150);

            cartesianChart1.LegendPosition = LiveChartsCore.Measure.LegendPosition.Left;
            cartesianChart1.LegendBackColor = System.Drawing.Color.FromArgb(255, 250, 250, 250);
            cartesianChart1.LegendTextColor = System.Drawing.Color.FromArgb(255, 50, 50, 50);
            cartesianChart1.LegendFont = new System.Drawing.Font("Courier New", 10);

            cartesianChart1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }
    }
}
