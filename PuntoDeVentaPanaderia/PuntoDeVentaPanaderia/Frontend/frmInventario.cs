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
    public partial class frmInventario : Form
    {

        private clsEmpleados empleadoActual;

        /// <summary>
        /// Inicializa los componentes, guarda el empleado actual y configura datos.
        /// </summary>
        /// <param name="empleado">Objeto que contiene la información del empleado, ys sabes para que apa</param>
        public frmInventario(clsEmpleados empleado)
        {
            InitializeComponent();
            this.empleadoActual = empleado;
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Maneja el evento de clic del botón para abrir el formulario de 'Agregar Pan'.
        /// Oculta la ventana actual, abre el formulario de alta y, al cerrarse, recarga el inventario.
        /// </summary>
        private void btnAgregarPan_Click(object sender, EventArgs e)
        {
            frmAgregarPan frmAPan = new frmAgregarPan(empleadoActual);
            this.Hide();
            frmAPan.ShowDialog();
            frmAPan.Focus();
            this.Show();
            CargarInventario();// Después de agregar un pan, recargar el inventario
        }

        /// <summary>
        /// Establece la configuración inicial
        /// para mostrar el inventario de panes de forma legible
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvInventario.AutoGenerateColumns = true;
            dgvInventario.ReadOnly = true;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.MultiSelect = false;
        }

        /// <summary>
        /// Obtiene la lista completa de panes desde la base de datos y la carga en el DataGridView.
        /// </summary>
        public void CargarInventario()
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            try
            {
                List<clsPanes> listaPanes = dao.obtenerPanes();
                dgvInventario.DataSource = listaPanes;
                dgvInventario.Refresh();
                RenombrarOcultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error de DB",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Se llama después de cargar los datos
        /// Se cambia nombre de columnas y ocualtamos la imagen
        /// </summary>
        private void RenombrarOcultarColumnas()
        {
            if (dgvInventario.Columns.Contains("idPan"))
                dgvInventario.Columns["idPan"].HeaderText = "CLAVE";

            if (dgvInventario.Columns.Contains("nombre"))
                dgvInventario.Columns["nombre"].HeaderText = "NOMBRE";

            if (dgvInventario.Columns.Contains("descripcion"))
                dgvInventario.Columns["descripcion"].HeaderText = "DESCRIPCIÓN";

            if(dgvInventario.Columns.Contains("categoria"))
                dgvInventario.Columns["categoria"].HeaderText = "CATEGORÍA";

            if (dgvInventario.Columns.Contains("precio"))
                dgvInventario.Columns["precio"].HeaderText = "PRECIO";

            if (dgvInventario.Columns.Contains("stock"))
                dgvInventario.Columns["stock"].HeaderText = "STOCK";

            if(dgvInventario.Columns.Contains("descontinuado"))
                dgvInventario.Columns["descontinuado"].HeaderText = "DESC.";

            if (dgvInventario.Columns.Contains("direccionImg"))
                dgvInventario.Columns["direccionImg"].Visible = false;
        }

        /// <summary>
        /// Obtiene la información completa del pan que el usuario tiene seleccionado
        /// Muestra una advertencia si no hay ninguna fila seleccionada.
        /// </summary>
        /// <returns>El pan, o null si no hay selección</returns>
        private clsPanes ObtenerPanSeleccionado()
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pan de la lista para continuar.", "Error de Selección",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            try
            {
                // Obtenemos la fila de datos
                return dgvInventario.SelectedRows[0].DataBoundItem as clsPanes;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener los datos del pan seleccionado.", "Error Interno",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Bloquea la edición si el producto está descontinuado o si todo bien abre el formulario de edición
        /// </summary>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            clsPanes panSeleccionado = ObtenerPanSeleccionado();

            if (panSeleccionado == null)
            {
                return;
            }
            if (panSeleccionado.descontinuado)
            {
                MessageBox.Show("No se puede editar un producto que ha sido descontinuado.",
                                "Acción Bloqueada",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }


            frmAgregarPan frmEditarPan = new frmAgregarPan(empleadoActual, panSeleccionado);

            this.Hide();
            frmEditarPan.ShowDialog();
            this.Show();
            CargarInventario();
        }

        /// <summary>
        /// Marca el producto como descontinuado en la base de datos, o avisa si ya lo está.
        /// </summary>
        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            clsPanes panSeleccionado = ObtenerPanSeleccionado();

            if (panSeleccionado == null)
            {
                return;
            }

            if (panSeleccionado.descontinuado)
            {
                MessageBox.Show($"El producto '{panSeleccionado.nombre}' ya se encuentra descontinuado.",
                                "Producto Descontinuado",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show($"¿Está seguro que desea descontinuar el pan '{panSeleccionado.nombre}' (Clave: {panSeleccionado.idPan})?\nEsta acción es reversible.",
                                                 "Confirmar Descontinuación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                clsDaoPanaderia dao = new clsDaoPanaderia();
                try
                {
                    if (dao.descontinuarPan(panSeleccionado.idPan, empleadoActual.idEmpleado))
                    {
                        MessageBox.Show("El producto ha sido marcado como descontinuado exitosamente.", "Éxito",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo descontinuar el producto.", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar descontinuar el pan: " + ex.Message, "Error de DB",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                CargarInventario();
            }
        }
        

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
