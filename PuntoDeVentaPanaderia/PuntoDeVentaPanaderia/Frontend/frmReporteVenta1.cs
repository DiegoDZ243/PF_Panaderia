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
            estilizarTabla();
            
        }


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

            // Ajustar altura de cada fila
            int altoFilas = 0;
            foreach (DataGridViewRow fila in gridReporte.Rows)
            {
                fila.Height = 35;
                altoFilas += 35;
            }

            int anchoTotal = 0;
            foreach (DataGridViewColumn col in gridReporte.Columns)
            {
                anchoTotal += col.Width;
            }



            int alturaTotal = altoFilas + gridReporte.ColumnHeadersHeight + 2;
            gridReporte.Height = alturaTotal;
            gridReporte.ClientSize = new Size(anchoTotal-50, alturaTotal+5);

            gridReporte.Width = gridReporte.ClientSize.Width; 





            
            this.ClientSize = new Size(
                Math.Max(this.ClientSize.Width, gridReporte.ClientSize.Width + 20),
                Math.Max(this.ClientSize.Height, gridReporte.ClientSize.Height + 20)
            );

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

        private void gridReporte_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmReporteVenta1_Load(object sender, EventArgs e)
        {
            
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            clsDaoPanaderia dao=new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentas(dtpInicio.Value,dtpFin.Value); 
            estilizarTabla(); 
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            reportes = dao.mostrarReporteVentas(dtpInicio.Value, dtpFin.Value);
            estilizarTabla();
        }

        private void frmReporteVenta1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Dispose(); 
        }
    }
    

}
