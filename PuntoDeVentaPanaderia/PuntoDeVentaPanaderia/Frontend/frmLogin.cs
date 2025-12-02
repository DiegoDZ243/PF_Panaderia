using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.Frontend;
using PuntoDeVentaPanaderia.Pojos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaPanaderia
{
    public partial class frmLogin : Form
    {
        #region Funciones

        private bool ValidarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errUser.SetError(txtUsuario, "Campo obligatorio");
                return false;
            }

            if (txtUsuario.Text.Length < 4)
            {
                errUser.SetError(txtUsuario, "Mínimo 4 caracteres");
                return false;
            }

            if (txtUsuario.Text.Length > 50)
            {
                errUser.SetError(txtUsuario, "Máximo 50 caracteres");
                return false;
            }

            errUser.SetError(txtUsuario, "");
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

        private string CalcularSHA256(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        #endregion
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarPassword() && ValidarUsuario())
            {

                clsDaoPanaderia dao = new clsDaoPanaderia();
                clsEmpleados empleado = dao.autentificarEmpleado(txtUsuario.Text, CalcularSHA256(txtContrasena.Text));
                

                if (empleado != null)
                {
                    
                    MessageBox.Show("¡Bienvenido " + empleado.nombre +"! Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMenu frmm = new frmMenu(empleado);
                    if (dao.EsAdministrador(empleado.idEmpleado))
                    {
                        frmm.admin = true;
                    }
                    frmm.Show();
                    frmm.Focus();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario y/o Contraseña incorecta, por favor de revisar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña incorecta, por favor de revisar los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            ValidarPassword();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
