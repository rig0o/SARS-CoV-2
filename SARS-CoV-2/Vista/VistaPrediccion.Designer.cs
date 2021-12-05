
namespace SARS_CoV_2.Vista
{
    partial class VistaPrediccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.Entrenar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(78, 35);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(588, 159);
            this.cartesianChart1.TabIndex = 0;
            // 
            // Entrenar
            // 
            this.Entrenar.Location = new System.Drawing.Point(615, 374);
            this.Entrenar.Name = "Entrenar";
            this.Entrenar.Size = new System.Drawing.Size(113, 30);
            this.Entrenar.TabIndex = 1;
            this.Entrenar.Text = "Entrenar red";
            this.Entrenar.UseVisualStyleBackColor = true;
            // 
            // VistaPrediccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Entrenar);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "VistaPrediccion";
            this.Text = "Prediccion";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Button Entrenar;
    }
}