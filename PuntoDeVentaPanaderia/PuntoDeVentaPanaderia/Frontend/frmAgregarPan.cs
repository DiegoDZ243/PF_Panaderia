using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.Pojos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmAgregarPan : Form
    {
        private clsEmpleados empleadoActual;
        private clsPanes panActual; // Para modo edición
        private string rutaImagenSeleccionada = "";

        /// <summary>
        /// Constructor principal usado para dar de alta un nuevo producto.
        /// Inicializa el formulario en modo 'Agregar' y configura los listeners de teclado.
        /// </summary>
        /// <param name="empleado">Pa saber que empleado realiza modificaciones</param>
        public frmAgregarPan(clsEmpleados empleado)
        {
            this.empleadoActual = empleado;
            InitializeComponent();
            ConfigurarFormulario(false);
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtStock.KeyPress += new KeyPressEventHandler(txtStock_KeyPress);
        }

        /// <summary>
        /// Constructor usado para modificar un producto existente.
        /// Carga los datos del pan y configura el formulario en modo 'Edición'.
        /// </summary>
        /// <param name="empleado">Pa saber que empleado realiza modificaciones</param>
        /// <param name="panAEditar">Objeto clsPanes con la información del producto a modificar.</param>
        public frmAgregarPan(clsEmpleados empleado, clsPanes panAEditar)
        {
            this.empleadoActual = empleado;
            this.panActual = panAEditar;
            InitializeComponent();

            ConfigurarFormulario(true);
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtStock.KeyPress += new KeyPressEventHandler(txtStock_KeyPress);
            CargarDatosParaEdicion();
        }

        /// <summary>
        /// Ajusta el texto del título y de los botones del formulario
        /// </summary>
        /// <param name="esEdicion">Pa saber si estamos en modo edición o modo alta</param>
        private void ConfigurarFormulario(bool esEdicion)
        {
            if (esEdicion)
            {
                lblTitulo.Text = "Modificar Producto";
                btnAgregar.Text = "Guardar Cambios";
                btnLimpiar.Text = "Cancelar";
            }
            else
            {
                lblTitulo.Text = "Agregar Pan";
                btnAgregar.Text = "Agregar";
                btnLimpiar.Text = "Limpiar";
            }
        }

        /// <summary>
        /// Rellena todos los campos del formulario (nombre, precio, stock, imagen, etc.)
        /// con los datos del producto seleccionado para su edición.
        /// </summary
        private void CargarDatosParaEdicion()
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            if (panActual == null) return;

            txtNombre.Text = panActual.nombre;
            txtDescripcion.Text = panActual.descripcion;
            txtPrecio.Text = panActual.precio.ToString();
            txtStock.Text = panActual.stock.ToString();
            cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(panActual.categoria);

            // Cargar imagen
            if (!string.IsNullOrEmpty(panActual.direccionImg))
            {
                try
                {
                    // Obtiene la ruta
                    string rutaAbsoluta = dao.GuardarImagenEnProyecto(panActual.direccionImg);

                    if (File.Exists(rutaAbsoluta))
                    {
                        pctImagenPan.Image = Image.FromFile(rutaAbsoluta);
                        this.rutaImagenSeleccionada = panActual.direccionImg; 
                    }
                    else
                    {
                        pctImagenPan.Image = Properties.Resources.imagedefault;
                        this.rutaImagenSeleccionada = "";// Pa que no se pase de listo el usuario, lo forza a seleccionar otra
                    }
                }
                catch
                {
                    pctImagenPan.Image = Properties.Resources.imagedefault;
                }
            }
        }

        /// <summary>
        /// Consulta las categorías disponibles desde la base de datos (DB)
        /// y las carga en el ComboBox de Categoría.
        /// </summary>
        private void CargarCategorias()
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();

            try
            {
                List<string> categorias = dao.ObtenerCategoriasDesdeDB();

                cmbCategoria.Items.Clear();
                cmbCategoria.DataSource = categorias;

                if (cmbCategoria.Items.Count > 0)
                {
                    if (panActual == null)
                    {
                        cmbCategoria.SelectedIndex = 0; //default
                    }
                    else
                    {
                        cmbCategoria.SelectedIndex = cmbCategoria.FindStringExact(panActual.categoria);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error de Configuración",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento de clic en el botón 'Seleccionar Imagen'.
        /// Abre el diálogo para elegir un archivo de imagen y lo previsualiza.
        /// </summary>
        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivoOrigen = ofdImage.FileName;

                try
                {
                    pctImagenPan.Image = Image.FromFile(rutaArchivoOrigen); //Previzualización

                    this.rutaImagenSeleccionada = rutaArchivoOrigen;
                    errImagen.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.rutaImagenSeleccionada = "";
                    pctImagenPan.Image = null;
                }
            }

        }

        private void ofdImage_FileOk(object sender, CancelEventArgs e)
        {

        }

        /// <summary>
        /// Agrega o guarda cambios, depende
        /// Valida los campos, copia la imagen si es nueva y registra/actualiza el producto
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarEntradas())
            {
                return;
            }

            clsDaoPanaderia dao = new clsDaoPanaderia();
            string rutaFinalImagenDB = rutaImagenSeleccionada;

            // Copiar si es nueva, obtener URL si es existente
            try
            {
                if (panActual == null || !rutaImagenSeleccionada.StartsWith("panesImg", StringComparison.OrdinalIgnoreCase))
                {
                    rutaFinalImagenDB = dao.GuardarImagenEnProyecto(this.rutaImagenSeleccionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al copiar la imagen al directorio del proyecto: " + ex.Message,
                                "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal precio = decimal.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);
            string categoria = cmbCategoria.SelectedItem.ToString();
            string descripcionPan = txtDescripcion.Text.Trim();
            if (descripcionPan == string.Empty) { descripcionPan = null; }


            try
            {
                bool resultado = false;

                if (panActual == null) // MODO ALTA
                {
                    clsPanes nuevoPan = new clsPanes
                    {
                        nombre = txtNombre.Text.Trim(),
                        descripcion = descripcionPan,
                        precio = precio,
                        stock = stock,
                        direccionImg = rutaFinalImagenDB,
                        categoria = categoria
                    };
                    resultado = dao.registrarPan(nuevoPan, empleadoActual.idEmpleado);
                }
                else // MODO EDICIÓN
                {
                    panActual.nombre = txtNombre.Text.Trim();
                    panActual.descripcion = descripcionPan;
                    panActual.precio = precio;
                    panActual.stock = stock;
                    panActual.direccionImg = rutaFinalImagenDB;
                    panActual.categoria = categoria;

                    resultado = dao.actualizarPan(panActual, empleadoActual.idEmpleado);
                }

                if (resultado)
                {
                    MessageBox.Show("Producto guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message,
                                "Error de DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reinicia todos los campos del formulario y los ErrorProviders a sus valores iniciales.
        /// Si estamos editando, cierra el formulario.
        /// </summary>
        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            errNombre.Clear();
            errImagen.Clear();
            errPrecio.Clear(); 
            errStock.Clear();

            rutaImagenSeleccionada = "";
            try
            {
                pctImagenPan.Image = Properties.Resources.imagedefault;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Advertencia: No se pudo cargar la imagen por defecto: " + ex.Message);
            }
            cmbCategoria.SelectedIndex = 0;
            if (panActual != null)
            {
                this.Close();
            }
            else
            {
                ConfigurarFormulario(false);
            }
        }



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void pctImagenPan_Click(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAgregarPan_Load(object sender, EventArgs e)
        {
            CargarCategorias();

            if (panActual == null || string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                try
                {
                    pctImagenPan.Image = Properties.Resources.imagedefault;
                }
                catch (Exception) {  }
            }
        }

        /// <summary>
        /// Controla la entrada de teclado en el campo de Precio,
        /// </summary>
        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else if (e.KeyChar == '.')
            {
                if ((sender as TextBox).Text.Contains('.'))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// Controla la entrada de teclado en el campo de Stock,
        /// </summary>
        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Valida todos los campos obligatorios y su rango en caso de tenr
        /// </summary>
        /// <returns>Verrdadero si todo esta bien,si no pues no</returns>
        private bool ValidarEntradas()
        {
            bool isValid = true;
            errNombre.Clear();
            errImagen.Clear();
            errPrecio.Clear();
            errStock.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errNombre.SetError(txtNombre, "El nombre del producto es obligatorio.");
                isValid = false;
            }
            else if (txtNombre.Text.Length > 60)
            {
                errNombre.SetError(txtNombre, $"El nombre no puede exceder los 60 caracteres. Actual: {txtNombre.Text.Length}");
                isValid = false;
            }

            if (string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                errImagen.SetError(pctImagenPan, "Debe seleccionar una imagen para el producto.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                errPrecio.SetError(txtPrecio, "El precio es obligatorio.");
                isValid = false;
            }
            else if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                errPrecio.SetError(txtPrecio, "El precio debe ser un valor numérico positivo y válido.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtStock.Text))
            {
                errStock.SetError(txtStock, "El stock es obligatorio.");
                isValid = false;
            }
            else if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                errStock.SetError(txtStock, "El stock debe ser un número entero no negativo.");
                isValid = false;
            }

            if (cmbCategoria.SelectedItem == null && isValid)
            {
                MessageBox.Show("La Categoría es obligatoria.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!isValid)
            {
                if (errNombre.GetError(txtNombre) != string.Empty) txtNombre.Focus();
                else if (errPrecio.GetError(txtPrecio) != string.Empty) txtPrecio.Focus();
                else if (errStock.GetError(txtStock) != string.Empty) txtStock.Focus();

            }

            return isValid;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}
