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

        /// <summary>
        /// Valida el campo de texto del usuario (nombre de usuario).
        /// Verifica si el campo está vacío y si la longitud está dentro de los límites de 4 a 50 caracteres.
        /// Establece un ErrorProvider si la validación falla.
        /// </summary>
        /// <returns>True si el usuario es válido, False en caso contrario.</returns>
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

        /// <summary>
        /// Valida el campo de texto de la contraseña.
        /// Verifica si el campo está vacío y si la longitud está dentro de los límites de 4 a 64 caracteres.
        /// Establece un ErrorProvider si la validación falla.
        /// </summary>
        /// <returns>True si la contraseña es válida, False en caso contrario.</returns>
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

        /// <summary>
        /// Calcula el hash SHA256 de una cadena de entrada.
        /// Este método se utiliza para encriptar la contraseña antes de compararla con la base de datos.
        /// </summary>
        /// <param name="input">La cadena de texto a encriptar (la contraseña sin hash).</param>
        /// <returns>La representación en cadena del hash SHA256 de la entrada.</returns>
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

        /// <summary>
        /// Maneja el evento de clic del botón Ingresar.
        /// Primero valida los campos de usuario y contraseña. Si son válidos, 
        /// calcula el hash SHA256 de la contraseña e intenta autentificar al empleado en la base de datos.
        /// Si la autenticación es exitosa, abre el formulario principal (frmMenu) y oculta el login.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (ValidarPassword() && ValidarUsuario())
            {

                clsDaoPanaderia dao = new clsDaoPanaderia();
                clsEmpleados empleado = dao.autentificarEmpleado(txtUsuario.Text, CalcularSHA256(txtContrasena.Text));


                if (empleado != null)
                {

                    MessageBox.Show("¡Bienvenido " + empleado.nombre + "! Inicio de sesión exitoso.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtUsuario.
        /// Llama al método ValidarUsuario para realizar la validación al salir del campo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtContrasena.
        /// Llama al método ValidarPassword para realizar la validación al salir del campo.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            ValidarPassword();
        }

        /// <summary>
        /// Evento que se dispara al cargar la forma frmLogin.
        /// (Actualmente vacío, reservado para lógica de inicialización futura).
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}