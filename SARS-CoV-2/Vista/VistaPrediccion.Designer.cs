
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPredecir = new System.Windows.Forms.Button();
            this.btnEscenarioModificado = new System.Windows.Forms.Button();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cklIllapel = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cklOvalle = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbLaSerenaCoquimbo = new System.Windows.Forms.Label();
            this.cklPlanPasoLSCQ = new System.Windows.Forms.CheckedListBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Location = new System.Drawing.Point(113, 24);
            this.cartesianChart1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(672, 212);
            this.cartesianChart1.TabIndex = 0;
            this.cartesianChart1.Load += new System.EventHandler(this.cartesianChart1_Load);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPredecir);
            this.flowLayoutPanel1.Controls.Add(this.btnEscenarioModificado);
            this.flowLayoutPanel1.Controls.Add(this.btnEntrenar);
            this.flowLayoutPanel1.Controls.Add(this.btnExportar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(882, 483);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(323, 125);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnPredecir
            // 
            this.btnPredecir.Location = new System.Drawing.Point(3, 3);
            this.btnPredecir.Name = "btnPredecir";
            this.btnPredecir.Size = new System.Drawing.Size(145, 54);
            this.btnPredecir.TabIndex = 3;
            this.btnPredecir.Text = "Predecir";
            this.btnPredecir.UseVisualStyleBackColor = true;
            this.btnPredecir.Click += new System.EventHandler(this.btnPredecir_Click);
            // 
            // btnEscenarioModificado
            // 
            this.btnEscenarioModificado.Location = new System.Drawing.Point(154, 3);
            this.btnEscenarioModificado.Name = "btnEscenarioModificado";
            this.btnEscenarioModificado.Size = new System.Drawing.Size(161, 54);
            this.btnEscenarioModificado.TabIndex = 4;
            this.btnEscenarioModificado.Text = "Predecir Escenario Modificado";
            this.btnEscenarioModificado.UseVisualStyleBackColor = true;
            this.btnEscenarioModificado.Click += new System.EventHandler(this.btnEscenarioModificado_Click);
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(3, 64);
            this.btnEntrenar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(145, 51);
            this.btnEntrenar.TabIndex = 1;
            this.btnEntrenar.Text = "Entrenar red";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(154, 63);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(161, 51);
            this.btnExportar.TabIndex = 2;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cklIllapel);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(567, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(194, 148);
            this.panel4.TabIndex = 8;
            // 
            // cklIllapel
            // 
            this.cklIllapel.FormattingEnabled = true;
            this.cklIllapel.Items.AddRange(new object[] {
            "Fase 1",
            "Fase 2",
            "Fase 3",
            "Fase 4"});
            this.cklIllapel.Location = new System.Drawing.Point(3, 45);
            this.cklIllapel.Name = "cklIllapel";
            this.cklIllapel.Size = new System.Drawing.Size(75, 92);
            this.cklIllapel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Plan Paso a Paso Illapel";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cklOvalle);
            this.panel3.Location = new System.Drawing.Point(369, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(192, 149);
            this.panel3.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Plan Paso a Paso Ovalle";
            // 
            // cklOvalle
            // 
            this.cklOvalle.FormattingEnabled = true;
            this.cklOvalle.Items.AddRange(new object[] {
            "Fase 1",
            "Fase 2",
            "Fase 3",
            "Fase 4"});
            this.cklOvalle.Location = new System.Drawing.Point(3, 45);
            this.cklOvalle.Name = "cklOvalle";
            this.cklOvalle.Size = new System.Drawing.Size(84, 92);
            this.cklOvalle.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbLaSerenaCoquimbo);
            this.panel1.Controls.Add(this.cklPlanPasoLSCQ);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 149);
            this.panel1.TabIndex = 6;
            // 
            // lbLaSerenaCoquimbo
            // 
            this.lbLaSerenaCoquimbo.AutoSize = true;
            this.lbLaSerenaCoquimbo.Location = new System.Drawing.Point(3, 10);
            this.lbLaSerenaCoquimbo.Name = "lbLaSerenaCoquimbo";
            this.lbLaSerenaCoquimbo.Size = new System.Drawing.Size(349, 20);
            this.lbLaSerenaCoquimbo.TabIndex = 1;
            this.lbLaSerenaCoquimbo.Text = "Plan Paso a Paso Conurbacion La Serena/Coquimbo";
            this.lbLaSerenaCoquimbo.Click += new System.EventHandler(this.lbLaSerenaCoquimbo_Click);
            // 
            // cklPlanPasoLSCQ
            // 
            this.cklPlanPasoLSCQ.FormattingEnabled = true;
            this.cklPlanPasoLSCQ.Items.AddRange(new object[] {
            "Fase 1",
            "Fase 2",
            "Fase 3",
            "Fase 4"});
            this.cklPlanPasoLSCQ.Location = new System.Drawing.Point(15, 45);
            this.cklPlanPasoLSCQ.Name = "cklPlanPasoLSCQ";
            this.cklPlanPasoLSCQ.Size = new System.Drawing.Size(76, 92);
            this.cklPlanPasoLSCQ.TabIndex = 0;
            this.cklPlanPasoLSCQ.SelectedIndexChanged += new System.EventHandler(this.cklPlanPasoLSCQ_SelectedIndexChanged);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 568);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(94, 29);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Controls.Add(this.panel1);
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(23, 285);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(789, 265);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // VistaPrediccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 620);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VistaPrediccion";
            this.Text = "Prediccion";
            this.Load += new System.EventHandler(this.VistaPrediccion_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnPredecir;
        private System.Windows.Forms.Button btnEscenarioModificado;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbLaSerenaCoquimbo;
        private System.Windows.Forms.CheckedListBox cklPlanPasoLSCQ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckedListBox cklOvalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox cklIllapel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}