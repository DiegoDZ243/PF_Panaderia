using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.ControlesUsuario;
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
    public partial class frmFiltrosReporte2 : Form
    {
        private List<clsPanes> panesSeleccionados=new List<clsPanes>(); 
        public frmFiltrosReporte2()
        {
            InitializeComponent();
        }

        private void frmFiltrosReporte2_Load(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            List<clsPanes> panes = dao.obtenerPanes();

            foreach (clsPanes pan in panes)
            {
                cuElegirPan control = new cuElegirPan(pan);
                control.Imagen.Image = Image.FromFile(dao.GuardarImagenEnProyecto(pan.direccionImg));
                flpPanes.Controls.Add(control); 
            }

            lblTitulo.Location=new Point((this.ClientSize.Width-lblTitulo.Width)/2,lblTitulo.Location.Y);
            btnGenerarReporte.Location = new Point((this.ClientSize.Width - btnGenerarReporte.Width) / 2, btnGenerarReporte.Location.Y);
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodos.Checked)
            {
                foreach(Control ctrl in flpPanes.Controls)
                {
                    cuElegirPan control=(cuElegirPan)ctrl;
                    control.CajaCheck.Checked = true;
                }
            }
            else
            {
                foreach (Control ctrl in flpPanes.Controls)
                {
                    cuElegirPan control = (cuElegirPan)ctrl;
                    control.CajaCheck.Checked = false;
                }
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
            foreach(Control ctrl in flpPanes.Controls)
            {
                cuElegirPan control = (cuElegirPan)ctrl;
                if (control.CajaCheck.Checked)
                {
                    panesSeleccionados.Add(control.getInfoPan()); 
                }
            }

            if (panesSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un pan", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTablaReporte2 frm = new frmTablaReporte2(dtpMes1.Value,dtpMes2.Value, panesSeleccionados);
            this.Hide(); 
            frm.ShowDialog();
            frm.Focus();
            this.Show();
            panesSeleccionados.Clear();
        }


    }
}
