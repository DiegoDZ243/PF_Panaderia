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
    public partial class frmMenu : Form
    {
        public bool admin;
        clsEmpleados empleadoActual;
        public frmMenu(clsEmpleados empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {

            frmEmpleados frmEmp = new frmEmpleados();

            frmEmp.Show();
            frmEmp.Focus();

        }

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {

            frmAgregarEmpleado frmAEmp = new frmAgregarEmpleado(empleadoActual);
            this.Hide();
            frmAEmp.ShowDialog();
            frmAEmp.Focus();
            this.Show();
        }

        private void btnDetallesVentas_Click(object sender, EventArgs e)
        {
            frmReporteVenta1 reporteVenta = new frmReporteVenta1();
            this.Hide();
            reporteVenta.ShowDialog();
            reporteVenta.Focus();
            this.Show();

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            if (!dao.EsAdministrador(empleadoActual.idEmpleado))
            {
                btnAgregarEmpleado.Visible = false;
                btnCompararVentas.Visible = false;
                btnVerEmpleados.Visible = false;
                btnCompararVentas.Visible = false;
                btnDetallesVentas.Visible = false;
            }
        }

        private void btnAgregarPan_Click(object sender, EventArgs e)
        {
            frmAgregarPan frmAPan = new frmAgregarPan(empleadoActual);
            this.Hide();
            frmAPan.ShowDialog();
            frmAPan.Focus();
            this.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            frmInventario frmInv = new frmInventario(empleadoActual);
            this.Hide();
            frmInv.ShowDialog();
            frmInv.Focus();
            frmInv.Dispose(); 
            this.Show();
        }

        /// <summary>
        /// Permite mostrar el reporte de ventas 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompararVentas_Click(object sender, EventArgs e)
        {
            frmFiltrosReporte2 frm = new frmFiltrosReporte2(); 
            this.Hide();
            frm.ShowDialog();
            frm.Focus();
            this.Show();
        }

        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            frmVenta frmVender = new frmVenta(empleadoActual);
            this.Hide();
            frmVender.ShowDialog();
            frmVender.Focus();
            this.Show();
        }
    }
}