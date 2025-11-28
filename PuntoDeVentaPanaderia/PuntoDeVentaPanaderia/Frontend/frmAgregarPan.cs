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
            empleadoActual= empleado;
            InitializeComponent();
        }

        private void CargarCategorias()
        {
            // Crea una instancia del DAO
            clsDaoPanaderia dao = new clsDaoPanaderia();

            try
            {
                // Pedir lista
                List<string> categorias = new List<string> { "Trigo", "Centeno", "Integral", "Avena" };

                cmbCategoria.Items.Clear();
                cmbCategoria.DataSource=categorias;
                

                // Establecer una opción por defecto
                if (cmbCategoria.Items.Count > 0)
                {
                    cmbCategoria.SelectedIndex = 0;
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
            // 2. Mostrar el diálogo
            if (ofdImage.ShowDialog() == DialogResult.OK)
            {
                // 3. Obtener la ruta del archivo seleccionado
                string rutaArchivo = ofdImage.FileName;

                //Falta la lógica para copiar la imagen a una carpeta específica si es necesario
                MessageBox.Show("Ruta de la imagen seleccionada: " + rutaArchivo);
            }

        }

        private void ofdImage_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //if (!ValidarEntradas()) //Faltan validar las entradas
            //{
            //    return; // Detiene la ejecución si la validación falla
            //}

            // Obtener valores validados
            decimal precio = decimal.Parse(txtPrecio.Text);
            int stock = int.Parse(txtStock.Text);
            string categoria = cmbCategoria.SelectedItem.ToString();

            // 1. Crear el objeto POJO
            clsPanes nuevoPan = new clsPanes
            {
                // idPan no se incluye
                nombre = txtNombre.Text.Trim(),
                descripcion = txtDescripcion.Text.Trim(),
                precio = precio,
                stock = stock,
                direccionImg = rutaImagenSeleccionada, // Se guarda la ruta
                categoria = categoria
            };

            // 2. Llamar al DAO para registrar
            clsDaoPanaderia dao = new clsDaoPanaderia();
            try
            {
                if (dao.registrarPan(nuevoPan,empleadoActual.idEmpleado))
                {
                    MessageBox.Show("Producto registrado exitosamente.", "Éxito",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles(); // Limpia los campos después de guardar
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el producto.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Captura errores de la base de datos
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

            // Limpiar variables de soporte
            rutaImagenSeleccionada = "";

            // Limpiar el PictureBox y re-cargar el ComboBox
            pctImagenPan.Image = null;
            CargarCategorias(); // Llamada para asegurar que el ComboBox se restablezca

            txtNombre.Focus();
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

        }
    }
}
