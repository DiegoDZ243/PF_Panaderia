using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.ControlesUsuario;
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
    public partial class frmVenta : Form
    {
        private readonly clsDaoPanaderia dao = new clsDaoPanaderia();
        private List<string> categorias = new List<string>();
        private int indiceCategoriaActual = 0;
        private clsEmpleados empleadoActual;

        /// <summary>
        /// Agarra al empleado, ya se imaginaran para que
        /// Modifica la cuadricula del carrito
        /// </summary>
        /// <param name="empleado">empleado actual.</param>
        public frmVenta(clsEmpleados empleado)
        {
            InitializeComponent();
            this.empleadoActual = empleado;

            ConfigurarDataGridView();
            lblTotal.Text = 0.ToString("C2");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Carga las categorías disponibles desde la base de datos, inicializa el timer y muestra el catálogo inicial de panes.
        /// </summary>
        private void frmVenta_Load(object sender, EventArgs e)
        {
            try
            {
                categorias = dao.ObtenerCategoriasDesdeDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (empleadoActual != null)
            {
                lblEmpleado.Text = $"Empleado: {empleadoActual.nombre}";
            }
            else
            {
                lblEmpleado.Text = "Empleado: No Asignado"; //Esto no debería pasar
            }


            timer1.Interval = 1000;
            timer1.Start();

            if (categorias.Count > 0)
            {
                CargarCategoriaActual();
            }
            else
            {
                lblCategoria.Text = "SIN CATEGORÍAS";
            }
        }

        /// <summary>
        /// Valida que el carrito no esté vacío
        /// y que el empleado esté autenticado, pa qué se preguntaran, por si acaso les dire yo.
        /// </summary>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (empleadoActual == null || empleadoActual.idEmpleado <= 0)
            {
                MessageBox.Show("Error: No se puede confirmar la venta, el empleado no está autentificado correctamente.", "Error de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dgvCarrito.RowCount == 0)
            {
                MessageBox.Show("El carrito está vacío. Agregue panes para confirmar la venta.", "Venta Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<clsDetalleOrden> productosAComprar = new List<clsDetalleOrden>();
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                // Usamos la clave (idPan)
                int idPan = Convert.ToInt32(row.Cells["ColClave"].Value);
                int unidades = Convert.ToInt32(row.Cells["ColCantidad"].Value);
                decimal precio = Convert.ToDecimal(row.Cells["ColPrecioUnitario"].Value);

                clsDetalleOrden detalle = new clsDetalleOrden
                {
                    idPan = idPan,
                    unidades = unidades,
                    precio = precio
                };
                productosAComprar.Add(detalle);
            }

            try
            {
                // Pasamos el ID del empleado real
                bool exito = dao.registrarOrden(productosAComprar, empleadoActual.idEmpleado);

                if (exito)
                {
                    MessageBox.Show($"Venta confirmada con un total de {lblTotal.Text}. Se ha registrado la orden.", "Venta Confirmada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Hubo un problema al intentar registrar la orden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar la venta: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (categorias.Count > 0)
            {
                indiceCategoriaActual--;
                if (indiceCategoriaActual < 0)
                {
                    indiceCategoriaActual = categorias.Count - 1;
                }
                CargarCategoriaActual();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Limpia el FlowLayoutPanel y carga los panes que pertenecen a la categoría seleccionada
        /// Si la categoría no tiene panes, pues no se ve nada, asi de facil
        /// </summary>
        private void CargarCategoriaActual()
        {
            if (categorias.Count == 0) return;

            string categoria = categorias[indiceCategoriaActual];
            lblCategoria.Text = categoria.ToUpper();

            flpPanes.Controls.Clear();

            try
            {
                List<clsPanes> panes = dao.obtenerPanesPorCategoria(categoria);

                foreach (clsPanes pan in panes)
                {
                    cuPanItem control = new cuPanItem(pan);

                    control.Imagen.Click += new EventHandler(PanItem_Click);

                    try
                    {
                        string rutaImagen = dao.GuardarImagenEnProyecto(pan.direccionImg);
                        control.Imagen.Image = Image.FromFile(rutaImagen);
                    }
                    catch (Exception) { }

                    flpPanes.Controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los panes de la categoría: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (categorias.Count > 0)
            {
                indiceCategoriaActual = (indiceCategoriaActual + 1) % categorias.Count;
                CargarCategoriaActual();
            }
        }

        /// <summary>
        /// Obtiene el objeto clsPanes asociado y llama a la función para agregarlo/actualizarlo en el carrito
        /// </summary>
        private void PanItem_Click(object sender, EventArgs e)
        {
            cuPanItem controlClick = sender as cuPanItem;
            if (controlClick == null)
            {
                Control innerControl = sender as Control;
                if (innerControl != null)
                {
                    controlClick = innerControl.Parent as cuPanItem;
                }
            }

            if (controlClick != null)
            {
                clsPanes panSeleccionado = controlClick.getInfoPan();
                AgregarOActualizarPan(panSeleccionado);
            }
        }

        /// <summary>
        /// Agrega un pan al DataGridView del carrito o incrementa la cantidad si el pan ya existe.
        /// Llama a las funciones de actualización de subtotales y total.
        /// </summary>
        /// <param name="pan">Pan que se desea agregar o actualizar.</param>
        private void AgregarOActualizarPan(clsPanes pan)
        {
            string clavePan = pan.idPan.ToString();

            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["ColClave"].Value != null && row.Cells["ColClave"].Value.ToString() == clavePan) // Pan ya existe en el carrito
                {
                    int cantidad = Convert.ToInt32(row.Cells["ColCantidad"].Value);
                    cantidad++;
                    row.Cells["ColCantidad"].Value = cantidad;

                    ActualizarSubtotalFila(row, pan.precio, cantidad);
                    ActualizarTotal();
                    return;
                }
            }

            dgvCarrito.Rows.Add(
                pan.idPan,             
                pan.nombre,             
                pan.precio,             
                1,                      
                pan.precio              
            );

            ActualizarTotal();
            if (dgvCarrito.RowCount > 0) 
            {
                dgvCarrito.FirstDisplayedScrollingRowIndex = dgvCarrito.RowCount - 1; // última fila agregada
            }
        }

        /// <summary>
        /// Define la estructura del DataGridView del carrito, incluyendo las columnas de datos
        /// y las columnas de botones para sumar, restar y eliminar productos.
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvCarrito.Columns.Clear();

            // Columnas de Datos
            dgvCarrito.Columns.Add("ColClave", "Clave");
            dgvCarrito.Columns.Add("ColNombre", "Nombre");
            dgvCarrito.Columns.Add("ColPrecioUnitario", "Precio");
            dgvCarrito.Columns.Add("ColCantidad", "Cant.");
            dgvCarrito.Columns.Add("ColSubtotal", "Subtotal");

            dgvCarrito.Columns["ColClave"].Visible = false;
            dgvCarrito.Columns["ColNombre"].FillWeight = 150;
            dgvCarrito.Columns["ColPrecioUnitario"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["ColSubtotal"].DefaultCellStyle.Format = "C2";
            dgvCarrito.Columns["ColCantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Columnas de Botones
            DataGridViewButtonColumn btnRestar = new DataGridViewButtonColumn { Name = "ColRestar", Text = "-", UseColumnTextForButtonValue = true, Width = 30 };
            DataGridViewButtonColumn btnSumar = new DataGridViewButtonColumn { Name = "ColSumar", Text = "+", UseColumnTextForButtonValue = true, Width = 30 };
            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn { Name = "ColEliminar", Text = "X", UseColumnTextForButtonValue = true, Width = 30 };

            dgvCarrito.Columns.Add(btnRestar);
            dgvCarrito.Columns.Add(btnSumar);
            dgvCarrito.Columns.Add(btnEliminar);

            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.ReadOnly = true;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Maneja el evento de clic en las columnas de botones del DataGridView del carrito.
        /// Gestiona las acciones de incrementar (+), decrementar (-) o eliminar (X) un producto.
        /// </summary>
        private void dgvCarrito_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (!(dgvCarrito.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            DataGridViewRow row = dgvCarrito.Rows[e.RowIndex];
            string colName = dgvCarrito.Columns[e.ColumnIndex].Name;

            if (row.Cells["ColPrecioUnitario"].Value == null || row.Cells["ColCantidad"].Value == null) return; //Por si acaso

            decimal precioUnitario = Convert.ToDecimal(row.Cells["ColPrecioUnitario"].Value);
            int cantidad = Convert.ToInt32(row.Cells["ColCantidad"].Value);

            bool shouldUpdate = false; // Indica si se debe actualizar el subtotal y total should=deberia

            if (colName == "ColSumar")
            {
                cantidad++;
                shouldUpdate = true;
            }
            else if (colName == "ColRestar")
            {
                if (cantidad > 1) 
                {
                    cantidad--;
                    shouldUpdate = true;
                }
                else //Por si acaso la cantidad se hace 0, lo eliminamos ;v
                {
                    dgvCarrito.Rows.RemoveAt(e.RowIndex);
                    ActualizarTotal();
                    return;
                }
            }
            else if (colName == "ColEliminar")
            {
                dgvCarrito.Rows.RemoveAt(e.RowIndex);
                ActualizarTotal();
                return;
            }
            if (shouldUpdate)
            {
                row.Cells["ColCantidad"].Value = cantidad;
                ActualizarSubtotalFila(row, precioUnitario, cantidad);
                ActualizarTotal();
            }
        }

        /// <summary>
        /// Calcula y actualiza el valor subtotal de una fila específica en el DataGridView.
        /// </summary>
        /// <param name="row">Fila del DataGridView a actualizar.</param>
        /// <param name="precio">Precio unitario del producto.</param>
        /// <param name="cantidad">Nueva cantidad del producto.</param>
        private void ActualizarSubtotalFila(DataGridViewRow row, decimal precio, int cantidad)
        {
            decimal subtotal = precio * cantidad;
            row.Cells["ColSubtotal"].Value = subtotal;
        }

        /// <summary>
        /// Recalcula el monto total de la venta sumando los subtotales de todas las filas en el DataGridView
        /// </summary>
        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvCarrito.Rows)
            {
                if (row.Cells["ColSubtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["ColSubtotal"].Value);
                }
            }

            lblTotal.Text = total.ToString("C2");
        }

        /// <summary>
        /// Maneja el evento de clic en el botón 'Cancelar Venta'.
        /// Limpia completamente el carrito, resetea el total y recarga el catálogo de panes.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            dgvCarrito.Rows.Clear();
            lblTotal.Text = 0.ToString("C2");
            CargarCategoriaActual();
        }
    }
}
