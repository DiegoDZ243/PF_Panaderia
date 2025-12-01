namespace PuntoDeVentaPanaderia.Frontend
{
    partial class frmGraficaReporte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartReporteVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartReporteVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // chartReporteVentas
            // 
            chartArea1.Name = "ChartArea1";
            this.chartReporteVentas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartReporteVentas.Legends.Add(legend1);
            this.chartReporteVentas.Location = new System.Drawing.Point(55, 49);
            this.chartReporteVentas.Name = "chartReporteVentas";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartReporteVentas.Series.Add(series1);
            this.chartReporteVentas.Size = new System.Drawing.Size(719, 443);
            this.chartReporteVentas.TabIndex = 0;
            this.chartReporteVentas.Text = "chart1";
            // 
            // frmGraficaReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.chartReporteVentas);
            this.Name = "frmGraficaReporte";
            this.Text = "Gráfica Comparativa Entre Meses";
            this.Load += new System.EventHandler(this.frmGraficaReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartReporteVentas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartReporteVentas;
    }
}