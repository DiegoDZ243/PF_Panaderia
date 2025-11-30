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

        public frmAgregarPan(clsEmpleados empleado)
        {
            this.empleadoActual = empleado;
            InitializeComponent();
            ConfigurarFormulario(false);
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtStock.KeyPress += new KeyPressEventHandler(txtStock_KeyPress);
        }

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

        private void ConfigurarFormulario(bool esEdicion)
        {
            if (esEdicion)
            {
                lblTitulo.Text = "Modificar Producto Existente";
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

        private void CargarDatosParaEdicion()
        {
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
                    string rutaAbsoluta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, panActual.direccionImg);

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

        private void btnSeleccionarImagen_Click(object sender, EventArgs e)
        {
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivoOrigen = ofdImage.FileName;

                try
                {
                    pctImagenPan.Image = Image.FromFile(rutaArchivoOrigen); //Previzualización

                    this.rutaImagenSeleccionada = rutaArchivoOrigen;

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

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private bool ValidarEntradas()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrEmpty(rutaImagenSeleccionada) || 
                cmbCategoria.SelectedItem == null)
            {
                MessageBox.Show("Los campos Nombre, Precio, Stock, Categoría e Imagen son obligatorios.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un valor numérico positivo válido.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecio.Focus();
                return false;
            }

            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero no negativo.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStock.Focus();
                return false;
            }

            return true;
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
