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
        public frmInventario(clsEmpleados empleado)
        {
            InitializeComponent();
            this.empleadoActual = empleado;
            ConfigurarDataGridView();
        }

        private void btnAgregarPan_Click(object sender, EventArgs e)
        {
            frmAgregarPan frmAPan = new frmAgregarPan(empleadoActual);
            this.Hide();
            frmAPan.ShowDialog();
            frmAPan.Focus();
            this.Show();
            CargarInventario();// Después de agregar un pan, recargar el inventario
        }

        private void ConfigurarDataGridView()
        {
            dgvInventario.AutoGenerateColumns = true;
            dgvInventario.ReadOnly = true;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.MultiSelect = false;
        }

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            clsPanes panSeleccionado = ObtenerPanSeleccionado();

            if (panSeleccionado == null)
            {
                return;
            }

            frmAgregarPan frmEditarPan = new frmAgregarPan(empleadoActual, panSeleccionado);

            this.Hide();
            frmEditarPan.ShowDialog();
            this.Show();

            // Recargar
            CargarInventario();
        }

        private void btnDescontinuar_Click(object sender, EventArgs e)
        {
            clsPanes panSeleccionado = ObtenerPanSeleccionado();

            if (panSeleccionado == null)
            {
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
                    if (dao.descontinuarPan(panSeleccionado.idPan,empleadoActual.idEmpleado))
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

                // 3. Recargar el inventario
                CargarInventario();
            }
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            CargarInventario();
        }
    }
}
