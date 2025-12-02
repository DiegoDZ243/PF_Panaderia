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
        // Lista con los reportes generados en el form anterior (frmTablaReporte2)
        List<clsReporteVentaMes> reportesAGraficar;
        // Meses seleccionados
        DateTime mes1, mes2; 

        /// <summary>
        /// Constructor del formulario que muestra la gráfica con el resumen del reporte de 
        /// ventas
        /// </summary>
        /// <param name="reportes">Entradas del reporte de ventas</param>
        /// <param name="mes1">Primer mes seleccionado</param>
        /// <param name="mes2">Segundo mes seleccionado</param>
        public frmGraficaReporte(List<clsReporteVentaMes> reportes, DateTime mes1, DateTime mes2)
        {
            reportesAGraficar = reportes;
            this.mes1=mes1;
            this.mes2=mes2;
            InitializeComponent();
        }


        /// <summary>
        /// Función que asigna los valores de ventas para cada producto seleccionado. Se crean
        /// dos series una para el mes 1 y otra para el 2. La creación de dos series permite la 
        /// comparación de ventas para cada producto en los dos meses seleccionados.
        /// </summary>
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

        /// <summary>
        /// Función empleada para darle un mejor formato a la gráfica generada
        /// </summary>
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

        /// <summary>
        /// Evento disparado al cargar el formulario en el que se llaman las funciones para
        /// generar la gráfica y darle formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGraficaReporte_Load(object sender, EventArgs e)
        {
            generarGraficaDeReportes(); 
            ConfigurarVentanaYGrafica();
        }
    }
}
