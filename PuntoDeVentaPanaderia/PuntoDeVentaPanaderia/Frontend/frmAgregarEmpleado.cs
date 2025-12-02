using PuntoDeVentaPanaderia.Backend;
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

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmAgregarEmpleado : Form
    {
        private int idEmpleadoEdicion = 0;
        private clsEmpleados empleadoActual;
        private frmMenu menu;

        /// <summary>
        /// Constructor para crear un nuevo empleado.
        /// Inicializa la forma en modo de "Nuevo Empleado".
        /// </summary>
        public frmAgregarEmpleado()
        {
            InitializeComponent();
            this.idEmpleadoEdicion = 0;
            lblTitulo.Text = "Nuevo Empleado";
        }

        /// <summary>
        /// Constructor para editar un empleado existente.
        /// Inicializa la forma con los datos del empleado proporcionado y la configura en modo de "Editar Empleado".
        /// </summary>
        /// <param name="empleado">El objeto clsEmpleados con los datos a cargar para la edición.</param>
        public frmAgregarEmpleado(clsEmpleados empleado)
        {
            InitializeComponent();
            this.idEmpleadoEdicion = empleado.idEmpleado;

            txtNombre.Text = empleado.nombre;
            txtApellidos.Text = empleado.apellidos;
            txtUser.Text = empleado.usuario;
            txtTelefono.Text = empleado.telefono;
            txtContrasena.Enabled = false;
            txtContrasena.Text = "";
            rdbtnSi.Checked = empleado.admin;
            rdbtnNo.Checked = !empleado.admin;
            lblTitulo.Text = "Editar Empleado";
            btnAceptar.Text = "ACTUALIZAR DATOS";
        }


        #region funciones 

        /// <summary>
        /// Valida los campos de texto de Nombre y Apellido.
        /// Verifica que no estén vacíos, que tengan entre 3 y 50 caracteres, y que no contengan números.
        /// </summary>
        /// <param name="txt">El control TextBox a validar (txtNombre o txtApellidos).</param>
        /// <returns>True si la validación es exitosa, False en caso contrario.</returns>
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

        /// <summary>
        /// Valida el campo de texto del nombre de usuario.
        /// Verifica que no esté vacío y que tenga entre 4 y 50 caracteres.
        /// </summary>
        /// <returns>True si el usuario es válido, False en caso contrario.</returns>
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

        /// <summary>
        /// Valida el campo de texto del número de teléfono.
        /// Verifica que no esté vacío, que tenga entre 10 y 13 caracteres, y que contenga solo números.
        /// </summary>
        /// <returns>True si el teléfono es válido, False en caso contrario.</returns>
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

        /// <summary>
        /// Valida el campo de texto de la contraseña.
        /// Verifica que no esté vacío y que tenga entre 4 y 64 caracteres.
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
        /// Limpia todos los campos de texto y los indicadores de error (ErrorProvider) en la forma.
        /// </summary>
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

        /// <summary>
        /// Obtiene el valor booleano (True/False) de la selección de administrador.
        /// </summary>
        /// <returns>True si el radio button 'Si' está marcado, False si 'No' está marcado.</returns>
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

        /// <summary>
        /// Calcula el hash SHA256 de una cadena de entrada.
        /// Este método se utiliza para encriptar la contraseña antes de guardarla.
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

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtNombre.
        /// Llama al método de validación para el campo Nombre/Apellido.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            ValidarNombreApellido(txtNombre);
        }

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtApellidos.
        /// Llama al método de validación para el campo Nombre/Apellido.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            ValidarNombreApellido(txtApellidos);
        }

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtUsuario.
        /// Llama al método de validación para el campo Usuario.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtContrasena.
        /// Llama al método de validación para el campo Contraseña.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            ValidarPassword();
        }

        /// <summary>
        /// Maneja el evento Leave del campo de texto txtTelefono.
        /// Llama al método de validación para el campo Teléfono.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            ValidarTelefono();
        }

        /// <summary>
        /// Maneja el evento de clic del botón Aceptar (Registrar o Actualizar).
        /// Valida todos los campos, recopila los datos del empleado y llama al método DAO 
        /// para registrar un nuevo empleado o actualizar uno existente.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool nombreOk = ValidarNombreApellido(txtNombre);
            bool apellidoOk = ValidarNombreApellido(txtApellidos);
            bool usuarioOk = ValidarUsuario();
            bool telOk = ValidarTelefono();

            // La contraseña solo es obligatoria si es un registro nuevo (idEmpleadoEdicion == 0)
            bool passOk = (idEmpleadoEdicion > 0) ? true : ValidarPassword();

            if (!nombreOk || !apellidoOk || !usuarioOk || !passOk || !telOk)
            {
                MessageBox.Show("Por favor revise los campos marcados con error.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clsEmpleados empleado = new clsEmpleados();
            empleado.nombre = txtNombre.Text.Trim();
            empleado.apellidos = txtApellidos.Text.Trim();
            empleado.usuario = txtUser.Text.Trim();
            empleado.telefono = txtTelefono.Text.Trim();
            empleado.admin = rdbtnSi.Checked;
            clsDaoPanaderia dao = new clsDaoPanaderia();

            try
            {
                if (idEmpleadoEdicion == 0)
                {
                    // Registrar nuevo
                    empleado.contrasena = CalcularSHA256(txtContrasena.Text.Trim());

                    if (dao.registrarEmpleado(empleado))
                    {
                        MessageBox.Show("Empleado registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    // Actualizar
                    empleado.idEmpleado = this.idEmpleadoEdicion;

                    if (dao.actualizarEmpleado(empleado))
                    {
                        MessageBox.Show("Datos del empleado actualizados.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate") || ex.Message.ToLower().Contains("usuario"))
                {
                    MessageBox.Show("El nombre de usuario ya existe.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    errUser.SetError(txtUser, "Usuario ocupado");
                }
                else
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Evento que se dispara al cargar la forma frmAgregarEmpleado.
        /// (Actualmente vacío, reservado para lógica de inicialización futura).
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void frmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }
    }
}