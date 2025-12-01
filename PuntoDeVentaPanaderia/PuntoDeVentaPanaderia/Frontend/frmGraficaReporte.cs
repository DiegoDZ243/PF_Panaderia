using PuntoDeVentaPanaderia.Pojos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmGraficaReporte : Form
    {
        List<clsReporteVentaMes> reportesAGraficar;
        DateTime mes1, mes2; 
        public frmGraficaReporte(List<clsReporteVentaMes> reportes, DateTime mes1, DateTime mes2)
        {
            reportesAGraficar = reportes;
            this.mes1=mes1;
            this.mes2=mes2;
            InitializeComponent();
        }


        private void generarGraficaDeReportes()
        {
            chartReporteVentas.Series.Clear(); 
            chartReporteVentas.Titles.Clear();
            chartReporteVentas.ChartAreas[0].AxisX.Interval = 1;

            chartReporteVentas.Titles.Add("Reporte Comparativo de Ventas Entre Meses"); 

            Series serieMes1 = new Series("Ventas del mes de "+mes1.ToString("MMMM"));
            serieMes1.ChartType = SeriesChartType.Column;
            serieMes1.IsValueShownAsLabel = true;


            Series serieMes2 = new Series("Ventas del mes de " + mes2.ToString("MMMM"));
            serieMes2.ChartType = SeriesChartType.Column;
            serieMes2.IsValueShownAsLabel = true;


            foreach (clsReporteVentaMes r in reportesAGraficar)
            {
                serieMes1.Points.AddXY(r.nombre, r.ventasMes1); 
                serieMes2.Points.AddXY(r.nombre, r.ventasMes2);
            }

            chartReporteVentas.Series.Add(serieMes1);
            chartReporteVentas.Series.Add(serieMes2);

        }

        private void ConfigurarVentanaYGrafica()
        {

            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            chartReporteVentas.Dock = DockStyle.Fill;

            var chart = chartReporteVentas;

            chart.BackColor = Color.White;
            chart.ChartAreas[0].BackColor = Color.White;


            chart.Titles.Clear();
            Title titulo = new Title("Reporte Comparativo de Ventas Entre Meses");
            titulo.ForeColor = Color.FromArgb(40, 40, 40);
            titulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            chart.Titles.Add(titulo);


            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(50, 50, 50);
            chart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chart.ChartAreas[0].AxisX.LineColor = Color.FromArgb(160, 160, 160);
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
            chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chart.ChartAreas[0].AxisX.Interval = 1;


            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(50, 50, 50);
            chart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
            chart.ChartAreas[0].AxisY.LineColor = Color.FromArgb(160, 160, 160);
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(220, 220, 220);
            chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;


            if (chart.Legends.Count > 0)
            {
                chart.Legends[0].BackColor = Color.White;
                chart.Legends[0].ForeColor = Color.FromArgb(40, 40, 40);
                chart.Legends[0].Font = new Font("Segoe UI", 10);
            }


            foreach (Series s in chart.Series)
            {
                if (s.Name.Contains(mes1.ToString("MMMM")))
                    s.Color = Color.FromArgb(52, 152, 219);  

                else
                    s.Color = Color.FromArgb(230, 126, 34);  

                s.IsValueShownAsLabel = true;
                s.Font = new Font("Segoe UI", 10);
                s.LabelForeColor = Color.FromArgb(40, 40, 40);
            }
        }


        private void frmGraficaReporte_Load(object sender, EventArgs e)
        {
            generarGraficaDeReportes(); 
            ConfigurarVentanaYGrafica();
        }
    }
}
