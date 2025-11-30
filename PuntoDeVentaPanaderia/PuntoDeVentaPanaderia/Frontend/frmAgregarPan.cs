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

        private string rutaImagenSeleccionada = "";

        public frmAgregarPan(clsEmpleados empleado)
        {
            this.empleadoActual = empleado;
            InitializeComponent();

            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtStock.KeyPress += new KeyPressEventHandler(txtStock_KeyPress);
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
                    cmbCategoria.SelectedIndex = 0; //Valor default
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

            string rutaFinalImagenDB = "";
            clsDaoPanaderia dao = new clsDaoPanaderia();

            try
            {
                // Copiar imagen y retornar ruta para la BD
                rutaFinalImagenDB = dao.GuardarImagenEnProyecto(this.rutaImagenSeleccionada);
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

            clsPanes nuevoPan = new clsPanes
            {
                nombre = txtNombre.Text.Trim(),
                descripcion = descripcionPan,
                precio = precio,
                stock = stock,
                direccionImg = rutaFinalImagenDB,
                categoria = categoria
            };

            try
            {
                // Id empleado para audi
                if (dao.registrarPan(nuevoPan, empleadoActual.idEmpleado))
                {
                    MessageBox.Show("Producto registrado exitosamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el producto.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
