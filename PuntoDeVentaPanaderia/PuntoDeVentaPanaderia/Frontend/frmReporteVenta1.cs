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
    public partial class frmReporteVenta1 : Form
    {
        List<clsReporteVenta> reportes = new List<clsReporteVenta>();
        public frmReporteVenta1()
        {
            
            InitializeComponent();
            clsDaoPanaderia dao=new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentas(dtpInicio.Value, dtpFin.Value);
            gridReporte.AutoSize = true;
           
            
        }

        /// <summary>
        /// Función empleada para darle diseño al grid y llenarlo
        /// </summary>
        private void estilizarTabla()
        {
            gridReporte.Rows.Clear();
            gridReporte.RowHeadersVisible = false;


            // Agregar filas
            foreach (clsReporteVenta r in reportes)

            {
                gridReporte.Rows.Add(
                    r.clave,
                    r.nombre,
                    r.unidades,
                    "$" + r.monto
                );

            }


            int anchoTotal = 0;
            foreach (DataGridViewColumn col in  gridReporte.Columns)
            {
                anchoTotal += col.Width;
            }

            gridReporte.Width = anchoTotal;
            gridReporte.Height = 11*this.ClientSize.Height/12 - gridReporte.Location.Y;



            gridReporte.Location = new Point(
                (this.ClientSize.Width - gridReporte.Width) / 2,
                gridReporte.Location.Y
            );


            Color colorFondo = ColorTranslator.FromHtml("#E6EEF5");
            Color colorGrid = ColorTranslator.FromHtml("#D2DFEC");
            Color colorEncabezado = ColorTranslator.FromHtml("#4B6EA8");
            Color colorTextoEncabezado = Color.White;
            Color colorFilaAlterna = ColorTranslator.FromHtml("#F4F7FA");
            Color colorTexto = ColorTranslator.FromHtml("#1C2635");
            Color textColor = Color.FromArgb(30, 45, 60);

            this.BackColor = colorFondo;


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

            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = textColor;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            dtpInicio.Location = new Point(gridReporte.Location.X, dtpInicio.Location.Y);
            dtpFin.Location = new Point(gridReporte.Location.X+gridReporte.Width-dtpFin.Width, dtpFin.Location.Y);
            lblInicio.Location = new Point();
            lblFin.Location = new Point();
            lblInicio.Location = new Point(
                dtpInicio.Left + (dtpInicio.Width - lblInicio.Width) / 2,
                dtpInicio.Top - lblInicio.Height - 5
            );

            lblFin.Location = new Point(
                dtpFin.Left + (dtpFin.Width - lblFin.Width) / 2,
                dtpFin.Top - lblFin.Height - 5
            );
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2 +40, lblTitulo.Location.Y);
            pcbReporte.Location = new Point(this.ClientSize.Width/24, gridReporte.Location.Y);
            pcbReporte.Size = new Size(this.ClientSize.Width/6, this.ClientSize.Height / 5);
            pcbReporte2.Location = new Point(19*this.ClientSize.Width / 24, gridReporte.Location.Y);
            pcbReporte2.Size = new Size(this.ClientSize.Width / 6, this.ClientSize.Height / 5);
        }

        private void gridReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Evento disparado al cargar el formulario. Se manda llamar la función que le da formato al grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReporteVenta1_Load(object sender, EventArgs e)
        {
            estilizarTabla();
        }

        /// <summary>
        /// Evento disparado al cambiar la fecha del DateTime Picker. Cada vez que se hace se actualizan
        /// las entradas del grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            clsDaoPanaderia dao=new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentas(dtpInicio.Value,dtpFin.Value); 
            estilizarTabla(); 
        }

        /// Evento disparado al cambiar la fecha del DateTime Picker. Cada vez que se hace se actualizan
        /// las entradas del grid.
        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentas(dtpInicio.Value, dtpFin.Value);
            estilizarTabla();
        }

        /// <summary>
        /// Evento que se dispara al cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReporteVenta1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose(); 
        }


    }


}
