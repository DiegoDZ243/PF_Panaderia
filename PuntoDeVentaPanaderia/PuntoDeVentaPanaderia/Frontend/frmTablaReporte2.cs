using PuntoDeVentaPanaderia.Backend;
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

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmTablaReporte2 : Form
    {
        List<clsReporteVentaMes> reportes;
        List<clsReporteVentaMes> reportesMostrados=new List<clsReporteVentaMes>(); 
        List<clsPanes> panesSeleccionados; 
        DateTime mes1, mes2; 
        public frmTablaReporte2(DateTime mes1, DateTime mes2, List<clsPanes> panesSeleccionados)
        {
            this.mes1= mes1;
            this.mes2= mes2;
            this.panesSeleccionados= panesSeleccionados;    
            clsDaoPanaderia dao = new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentasMeses(mes1, mes2); 
            InitializeComponent();
        }



        private void estilizarTabla()
        {
            gridReporte.Rows.Clear();
            gridReporte.RowHeadersVisible = false;


            // Agregar filas
            foreach (clsReporteVentaMes r in reportes)
            {
                if (panesSeleccionados.Contains(new clsPanes(r.clave)))
                {
                    reportesMostrados.Add(r);
                    gridReporte.Rows.Add(
                        r.clave,
                        r.nombre,
                        "$" + r.precio,
                        "$" + r.ventasMes1,
                        "$" + r.ventasMes2
                    );
                }
            }


            int anchoTotal = 0;
            foreach (DataGridViewColumn col in gridReporte.Columns)
            {
                anchoTotal += col.Width;
            }

            gridReporte.Width = anchoTotal+110;

            this.Width = gridReporte.Width + 50; 




            //this.ClientSize = new Size(
            //    Math.Max(this.ClientSize.Width, gridReporte.Width + 20),
            //    Math.Max(this.ClientSize.Height, gridReporte.Height + 20)
            //);

            gridReporte.Location = new Point(
                (this.ClientSize.Width - gridReporte.Width) / 2,
                gridReporte.Location.Y
            );


            gridReporte.BackgroundColor = Color.FromArgb(35, 35, 35);
            gridReporte.BorderStyle = BorderStyle.None;


            gridReporte.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 60, 68);
            gridReporte.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            gridReporte.EnableHeadersVisualStyles = false;

            gridReporte.DefaultCellStyle.BackColor = Color.FromArgb(80, 80, 80);
            gridReporte.DefaultCellStyle.ForeColor = Color.White;
            gridReporte.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(65, 65, 65);
            gridReporte.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
            gridReporte.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70);
            gridReporte.DefaultCellStyle.SelectionForeColor = Color.White;

        }

        private void btnGrafica_Click(object sender, EventArgs e)
        {
            frmGraficaReporte frm = new frmGraficaReporte(reportesMostrados, mes1, mes2);
            this.Hide(); 
            frm.ShowDialog();
            frm.Focus();
            frm.Dispose(); 
            this.Show(); 
        }

        private void frmTablaReporte2_Load(object sender, EventArgs e)
        {
            gridReporte.Rows.Clear();
            gridReporte.Columns.Clear();

            //Agregar columnas
            gridReporte.Columns.Add("clave", "Clave");
            gridReporte.Columns.Add("nombre", "Nombre");
            gridReporte.Columns.Add("precio", "Precio");
            gridReporte.Columns.Add("ventasMes1", "Ventas de " +mes1.ToString("MMMM"));
            gridReporte.Columns.Add("ventasMes2", "Ventas de "+ mes2.ToString("MMMM"));
            estilizarTabla();

            btnGrafica.Location = new Point((this.ClientSize.Width - btnGrafica.Width) / 2, btnGrafica.Location.Y); 
        }
    }
}
