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

        /// <summary>
        /// Constructor de la forma frmMenu.
        /// Inicializa los componentes de la interfaz de usuario y establece el empleado actual.
        /// </summary>
        /// <param name="empleado">Objeto clsEmpleados del usuario que inició sesión.</param>
        public frmMenu(clsEmpleados empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;

        }

        /// <summary>
        /// Evento que se dispara al cerrar la forma del menú principal.
        /// Asegura que la aplicación completa se cierre.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento de cierre de la forma.</param>
        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Ver Empleados.
        /// Muestra la forma para administrar la lista de empleados (frmEmpleados).
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnVerEmpleados_Click(object sender, EventArgs e)
        {

            frmEmpleados frmEmp = new frmEmpleados();

            frmEmp.Show();
            frmEmp.Focus();

        }


        /// <summary>
        /// Maneja el evento de clic del botón Detalles Ventas.
        /// Oculta el menú actual y muestra la forma del Reporte de Venta 1 (frmReporteVenta1) como diálogo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnDetallesVentas_Click(object sender, EventArgs e)
        {
            frmReporteVenta1 reporteVenta = new frmReporteVenta1();
            this.Hide();
            reporteVenta.ShowDialog();
            reporteVenta.Focus();
            this.Show();

        }

        /// <summary>
        /// Evento que se dispara al cargar la forma frmMenu.
        /// Verifica si el empleado actual es administrador y oculta los botones de administración 
        /// y reportes si no lo es.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void frmMenu_Load(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            if (!dao.EsAdministrador(empleadoActual.idEmpleado))
            {

                btnCompararVentas.Visible = false;
                btnVerEmpleados.Visible = false;
                btnCompararVentas.Visible = false;
                btnDetallesVentas.Visible = false;
                btnAuditorias.Visible = false;
                lblTitulo.Location = new Point((this.panelContenedor.Width - lblTitulo.Width) / 2, lblTitulo.Location.Y);
            }
        }

        /// <summary>
        /// Maneja el evento de clic del botón Agregar Pan.
        /// Oculta el menú actual y muestra la forma para Agregar/Editar Pan (frmAgregarPan) como diálogo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnAgregarPan_Click(object sender, EventArgs e)
        {
            frmAgregarPan frmAPan = new frmAgregarPan(empleadoActual);
            this.Hide();
            frmAPan.ShowDialog();
            frmAPan.Focus();
            this.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Inventario.
        /// Oculta el menú actual y muestra la forma del Inventario (frmInventario) como diálogo.
        /// Dispone la forma de Inventario después de cerrarse para liberar recursos.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
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
        /// Permite mostrar el reporte de ventas 2.
        /// Oculta el menú actual y muestra la forma de Filtros de Reporte 2 (frmFiltrosReporte2) como diálogo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnCompararVentas_Click(object sender, EventArgs e)
        {
            frmFiltrosReporte2 frm = new frmFiltrosReporte2();
            this.Hide();
            frm.ShowDialog();
            frm.Focus();
            this.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Realizar Venta.
        /// Oculta el menú actual y muestra la forma de Venta (frmVenta) como diálogo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnRealizarVenta_Click(object sender, EventArgs e)
        {
            frmVenta frmVender = new frmVenta(empleadoActual);
            this.Hide();
            frmVender.ShowDialog();
            frmVender.Focus();
            this.Show();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Auditorías.
        /// Oculta el menú actual y muestra la forma de Auditorías (frmAuditorias) como diálogo.
        /// Dispone la forma de Auditorías después de cerrarse para liberar recursos.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnAuditorias_Click(object sender, EventArgs e)
        {
            frmAuditorias frm = new frmAuditorias();
            this.Hide();
            frm.ShowDialog();
            frm.Focus();
            frm.Dispose();
            this.Show();
        }
    }
}