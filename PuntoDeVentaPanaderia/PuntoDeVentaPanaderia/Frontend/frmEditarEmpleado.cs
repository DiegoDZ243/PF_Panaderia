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
    public partial class frmEditarEmpleado : Form
    {
        private clsEmpleados empleado;
        public bool datosActualizados = false; 
        public frmEditarEmpleado(clsEmpleados empleado)
        {
            this.empleado = empleado;
            InitializeComponent();
        }


        #region VALIDACIONES

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

        

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellidos.Clear();
            txtUser.Clear();
            txtTelefono.Clear();
            errNombreApellido.Clear();
            errUser.Clear();
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

        private bool datosValidados()
        {
            return ValidarNombreApellido(txtApellidos) && ValidarNombreApellido(txtNombre) &&
                ValidarUsuario() && ValidarTelefono();
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!datosValidados())
                {
                    MessageBox.Show("Por favor revise los campos marcados con error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                
                }
                clsEmpleados empleadoActualizado = new clsEmpleados();
                empleadoActualizado.idEmpleado = empleado.idEmpleado; 
                empleadoActualizado.nombre = txtNombre.Text.Trim();
                empleadoActualizado.apellidos = txtApellidos.Text.Trim();
                empleadoActualizado.usuario = txtUser.Text.Trim();
                empleadoActualizado.contrasena = empleado.contrasena; 
                empleadoActualizado.telefono = txtTelefono.Text.Trim();
                empleadoActualizado.admin = rdbtnSi.Checked; 


                clsDaoPanaderia dao = new clsDaoPanaderia();
                if (dao.actualizarEmpleado(empleadoActualizado))
                {
                    datosActualizados = true; 
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                    this.Hide();
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

        private void frmEditarEmpleado_Load(object sender, EventArgs e)
        {
            txtNombre.Text = empleado.nombre;
            txtApellidos.Text = empleado.apellidos;
            txtTelefono.Text = empleado.telefono;
            txtUser.Text = empleado.usuario;
            rdbtnSi.Checked = empleado.admin;
            rdbtnNo.Checked = !empleado.admin;
        }
    }
}
