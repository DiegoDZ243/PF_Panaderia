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
        clsEmpleados empleadoActual; 
        public frmMenu(clsEmpleados empleado)
        {
            InitializeComponent();
            empleadoActual= empleado;

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
    }
}
