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
    public partial class frmAuditorias : Form
    {
        private List<clsAuditoria> auditorias;
        public frmAuditorias()
        {
            clsDaoPanaderia dao=new clsDaoPanaderia();
            auditorias=dao.obtenerAuditorias();
            InitializeComponent();
        }

        private void estilizarTabla()
        {
            gridAuditorias.Rows.Clear();
            gridAuditorias.RowHeadersVisible = false;


            // Agregar filas
            foreach (clsAuditoria a in auditorias)
            {
                
                gridAuditorias.Rows.Add(
                    a.nombre,
                    a.cambio,
                    a.usuario,
                    "$"+a.precioAnterior,
                    "$"+a.precioNuevo,
                    a.fecha
                );
                
            }


            int anchoTotal = 0;
            foreach (DataGridViewColumn col in  gridAuditorias.Columns)
            {
                anchoTotal += col.Width;
            }

            gridAuditorias.Width = anchoTotal + 70;

            this.Width = gridAuditorias.Width + 50;


            gridAuditorias.Location = new Point(
                (this.ClientSize.Width - gridAuditorias.Width) / 2,
                gridAuditorias.Location.Y
            );


            Color colorFondo = ColorTranslator.FromHtml("#E6EEF5");
            Color colorGrid = ColorTranslator.FromHtml("#D2DFEC");
            Color colorEncabezado = ColorTranslator.FromHtml("#4B6EA8");
            Color colorTextoEncabezado = Color.White;
            Color colorFilaAlterna = ColorTranslator.FromHtml("#F4F7FA");
            Color colorTexto = ColorTranslator.FromHtml("#1C2635");


            this.BackColor = colorFondo;


            gridAuditorias.BackgroundColor = colorGrid;
            gridAuditorias.BorderStyle = BorderStyle.None;

            gridAuditorias.EnableHeadersVisualStyles = false;
            gridAuditorias.ColumnHeadersDefaultCellStyle.BackColor = colorEncabezado;
            gridAuditorias.ColumnHeadersDefaultCellStyle.ForeColor = colorTextoEncabezado;
            gridAuditorias.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold);

            gridAuditorias.DefaultCellStyle.BackColor = Color.White;
            gridAuditorias.DefaultCellStyle.ForeColor = colorTexto;
            gridAuditorias.AlternatingRowsDefaultCellStyle.BackColor = colorFilaAlterna;
            gridAuditorias.DefaultCellStyle.Font = new Font("Arial", 12);

            gridAuditorias.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridAuditorias.GridColor = ColorTranslator.FromHtml("#A8BBD1");
        }

        private void frmAuditorias_Load(object sender, EventArgs e)
        {
            gridAuditorias.Columns.Clear();
            gridAuditorias.Rows.Clear();
            gridAuditorias.Columns.Add("pan", "Nombre del producto"); 
            gridAuditorias.Columns.Add("cambio", "Cambio realizado");
            gridAuditorias.Columns.Add("usuario", "Hecho por el empleado");
            gridAuditorias.Columns.Add("precioAnterior", "Precio Anterior");
            gridAuditorias.Columns.Add("precioNuevo", "Precio Nuevo");
            gridAuditorias.Columns.Add("fecha", "Realizado el día");
            estilizarTabla();
            lblTitulo.Location = new Point((this.ClientSize.Width - lblTitulo.Width) / 2, lblTitulo.Location.Y);
        }
    }
}
