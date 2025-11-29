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
    public partial class frmAgregarEmpleado : Form
    {
        private clsEmpleados empleadoActual; 
        private frmMenu menu; 
        public frmAgregarEmpleado(clsEmpleados empleado)
        {
            empleadoActual = empleado;
            InitializeComponent();
        }

        public frmAgregarEmpleado()
        {

        }


        #region funciones 

        private bool ValidarNombreApellido(TextBox txt)
        {
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                errNombreApellido.SetError(txt, "Campo obligatorio");
                return false;
            }

            if (txt.Text.Length < 3)
            {
                errNombreApellido.SetError(txt, "Mínimo 3 caracteres");
                return false;
            }

            if (txt.Text.Length > 50)
            {
                errNombreApellido.SetError(txt, "Máximo 50 caracteres");
                return false;
            }

            foreach (char c in txt.Text)
            {
                if (char.IsDigit(c))
                {
                    errNombreApellido.SetError(txt, "No debe contener números");
                    return false;
                }
            }

            errNombreApellido.SetError(txt, "");
            return true;
        }
        private bool ValidarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                errUser.SetError(txtUser, "Campo obligatorio");
                return false;
            }

            if (txtUser.Text.Length < 4)
            {
                errUser.SetError(txtUser, "Mínimo 4 caracteres");
                return false;
            }

            if (txtUser.Text.Length > 50)
            {
                errUser.SetError(txtUser, "Máximo 50 caracteres");
                return false;
            }

            errUser.SetError(txtUser, "");
            return true;
        }

        private bool ValidarTelefono()
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                errTelefono.SetError(txtTelefono, "Campo obligatorio");
                return false;
            }

            if (txtTelefono.Text.Length < 10)
            {
                errTelefono.SetError(txtTelefono, "Mínimo 10 caracteres");
                return false;
            }

            if (txtTelefono.Text.Length > 13)
            {
                errTelefono.SetError(txtTelefono, "Máximo 13 caracteres");
                return false;
            }

            foreach (char c in txtTelefono.Text)
            {
                if (c < '0' || c > '9')
                {
                    errTelefono.SetError(txtTelefono, "Solo se permiten números");
                    return false;
                }
            }

            errTelefono.SetError(txtTelefono, "");
            return true;
        }

        private bool ValidarPassword()
        {
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                errPass.SetError(txtContrasena, "Campo obligatorio");
                return false;
            }

            if (txtContrasena.Text.Length < 4)
            {
                errPass.SetError(txtContrasena, "Mínimo 4 caracteres");
                return false;
            }

            if (txtContrasena.Text.Length > 64)
            {
                errPass.SetError(txtContrasena, "Máximo 64 caracteres");
                return false;
            }

            errPass.SetError(txtContrasena, "");
            return true;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtUser.Clear();
            txtContrasena.Clear();
            txtTelefono.Clear();
            errNombreApellido.Clear();
            errUser.Clear();
            errPass.Clear();
            errTelefono.Clear();
        }

        public bool ObtenerSeleccion()
        {
            if (rdbtnSi.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            ValidarNombreApellido(txtNombre);
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            ValidarNombreApellido(txtApellidos);
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            ValidarPassword();
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            ValidarTelefono();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool nombreOk = ValidarNombreApellido(txtNombre);
            bool apellidoOk = ValidarNombreApellido(txtApellidos);
            bool usuarioOk = ValidarUsuario();
            bool passOk = ValidarPassword();
            bool telOk = ValidarTelefono();
            bool admin = ObtenerSeleccion();

            if (!nombreOk || !apellidoOk || !usuarioOk || !passOk || !telOk)
            {
                MessageBox.Show("Por favor revise los campos marcados con error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEmpleados nuevoEmpleado = new clsEmpleados();
            nuevoEmpleado.nombre = txtNombre.Text.Trim();
            nuevoEmpleado.apellidos = txtApellidos.Text.Trim();
            nuevoEmpleado.usuario = txtUser.Text.Trim();
            nuevoEmpleado.contrasena = txtContrasena.Text.Trim();
            nuevoEmpleado.telefono = txtTelefono.Text.Trim();
            nuevoEmpleado.admin = admin;

            clsDaoPanaderia dao = new clsDaoPanaderia();

            try
            {
                if (dao.registrarEmpleado(nuevoEmpleado))
                {

                    MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    this.Hide(); 
                    menu.ShowDialog();
                    menu.Focus();
                    this.Close();
                    this.Dispose(); 

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate") || ex.Message.ToLower().Contains("usuario"))
                {
                    MessageBox.Show("El nombre de usuario ya existe. Por favor elija otro.", "Usuario Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errUser.SetError(txtUser, "Este usuario ya está ocupado");
                    txtUser.Focus();
                }
                else
                {
                    MessageBox.Show("Error al guardar: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}
