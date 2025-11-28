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
        public frmMenu()
        {
            InitializeComponent();
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
            
            frmAgregarEmpleado frmAEmp = new frmAgregarEmpleado();
           
            frmAEmp.Show();
            frmAEmp.Focus();
            
        }
    }
}
