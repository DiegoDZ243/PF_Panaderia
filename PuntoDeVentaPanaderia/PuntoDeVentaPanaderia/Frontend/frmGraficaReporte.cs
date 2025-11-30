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
        private void frmGraficaReporte_Load(object sender, EventArgs e)
        {
            generarGraficaDeReportes(); 
        }
    }
}
