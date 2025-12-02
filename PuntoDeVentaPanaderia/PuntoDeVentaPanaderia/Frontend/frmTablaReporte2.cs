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


        /// <summary>
        /// Función empleada para llenar y darle formato al grid
        /// </summary>
        private void estilizarTabla()
        {
            gridReporte.Rows.Clear();
            gridReporte.RowHeadersVisible = false;


            // Agregar filas
            foreach (clsReporteVentaMes r in reportes)
            {
                //Se muestra el reporte solo de los panes seleccionados
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

            //Se calcula qué tan ancha será la tabla para ajustarla
            int anchoTotal = 0;
            foreach (DataGridViewColumn col in gridReporte.Columns)
            {
                anchoTotal += col.Width;
            }

            gridReporte.Width = anchoTotal+150;

            this.Width = gridReporte.Width + 50; 


            gridReporte.Location = new Point(
                (this.ClientSize.Width - gridReporte.Width) / 2,
                gridReporte.Location.Y+50
            );

            

            gridReporte.BackgroundColor = Color.FromArgb(35, 35, 35);
            gridReporte.BorderStyle = BorderStyle.None;

            //Colores empleados para el form
            Color colorFondo = ColorTranslator.FromHtml("#E6EEF5");
            Color colorGrid = ColorTranslator.FromHtml("#D2DFEC");
            Color colorEncabezado = ColorTranslator.FromHtml("#4B6EA8");
            Color colorTextoEncabezado = Color.White;
            Color colorFilaAlterna = ColorTranslator.FromHtml("#F4F7FA");
            Color colorTexto = ColorTranslator.FromHtml("#1C2635");
            Color botonColor = Color.FromArgb(40, 85, 140);        

            this.BackColor = colorFondo;


            btnGrafica.FlatStyle = FlatStyle.Flat;
            btnGrafica.FlatAppearance.BorderSize = 0;
            btnGrafica.BackColor = botonColor;
            btnGrafica.ForeColor = Color.White;
            btnGrafica.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGrafica.Height = 45;
            btnGrafica.Width = 180;
            btnGrafica.Cursor = Cursors.Hand;
            btnGrafica.Location = new Point(btnGrafica.Location.X, btnGrafica.Location.Y + 60); 

            gridReporte.BackgroundColor = colorGrid;
            gridReporte.BorderStyle = BorderStyle.None;

            gridReporte.EnableHeadersVisualStyles = false;
            gridReporte.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            gridReporte.ColumnHeadersDefaultCellStyle.ForeColor = colorTextoEncabezado;
            gridReporte.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 18, FontStyle.Bold);

            gridReporte.DefaultCellStyle.BackColor = Color.White;
            gridReporte.DefaultCellStyle.ForeColor = colorTexto;
            gridReporte.AlternatingRowsDefaultCellStyle.BackColor = colorFilaAlterna;
            gridReporte.DefaultCellStyle.Font = new Font("Arial", 16);

            gridReporte.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridReporte.GridColor = ColorTranslator.FromHtml("#A8BBD1");

            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, lblTitulo.Location.Y+50);
            
            pcbReporte.Size=new Size(this.ClientSize.Width/8, this.ClientSize.Width / 8);
            pcbReporte.Location = new Point(this.ClientSize.Width / 24, gridReporte.Location.Y);
            pcbReporte2.Size = new Size(this.ClientSize.Width / 8, this.ClientSize.Width / 8);
            pcbReporte2.Location = new Point(10*this.ClientSize.Width / 12, gridReporte.Location.Y);
        }

        /// <summary>
        /// Evento disparado al hacer clic en el botón "Generar gráfica". Pasa los parametros de
        /// este formulario a frmGraficaReporte para generar la gráfica con los datos requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrafica_Click(object sender, EventArgs e)
        {
            frmGraficaReporte frm = new frmGraficaReporte(reportesMostrados, mes1, mes2);
            this.Hide(); 
            frm.ShowDialog();
            frm.Focus();
            frm.Dispose(); 
            this.Show(); 
        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario. En el se asignan las columnas que se emplearán
        /// y se mandan llamar las funciones para darle diseño
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
