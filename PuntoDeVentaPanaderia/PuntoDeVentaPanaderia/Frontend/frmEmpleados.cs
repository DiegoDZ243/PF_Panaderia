using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.Pojos;

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmEmpleados : Form
    {
        clsDaoPanaderia dao = new clsDaoPanaderia();

        public frmEmpleados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que se dispara al cargar la forma frmEmpleados.
        /// Llama a los métodos para cargar y configurar la cuadrícula de empleados.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrid();
            ConfigurarGrid();
        }

        /// <summary>
        /// Carga los datos de los empleados desde la base de datos a la cuadrícula (DataGridView).
        /// Muestra un mensaje de error si la carga falla.
        /// </summary>
        private void CargarGrid()
        {
            try
            {
                List<clsEmpleados> lista = dao.obtenerEmpleados();
                dtgEmpleados.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Configura la apariencia y el comportamiento del DataGridView (dtgEmpleados).
        /// Oculta la columna de "contrasena" y establece modos de selección y redimensionamiento.
        /// </summary>
        private void ConfigurarGrid()
        {
            if (dtgEmpleados.Columns.Count > 0)
            {
                if (dtgEmpleados.Columns["contrasena"] != null)
                    dtgEmpleados.Columns["contrasena"].Visible = false;

                dtgEmpleados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dtgEmpleados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dtgEmpleados.MultiSelect = false;
                dtgEmpleados.ReadOnly = true;
            }
        }

        /// <summary>
        /// Maneja el clic del botón Desactivar.
        /// Pide confirmación al usuario y llama al método para desactivar al empleado seleccionado.
        /// Muestra un mensaje de éxito o error y recarga la cuadrícula.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dtgEmpleados.CurrentRow != null)
            {
                clsEmpleados empleadoSeleccionado = (clsEmpleados)dtgEmpleados.CurrentRow.DataBoundItem;

                DialogResult respuesta = MessageBox.Show(
                    "¿Estás seguro de desactivar al empleado " + empleadoSeleccionado.nombre + "?",
                    "Confirmar Baja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    try
                    {
                        if (dao.desactivarEmpleado(empleadoSeleccionado.idEmpleado))
                        {
                            MessageBox.Show("Empleado desactivado correctamente.");
                            CargarGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado de la lista.");
            }
        }

        /// <summary>
        /// Maneja el clic del botón Editar.
        /// Abre la forma de Agregar/Editar Empleado (frmAgregarEmpleado) en modo edición 
        /// con los datos del empleado seleccionado. Recarga la cuadrícula al cerrar la forma.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgEmpleados.CurrentRow != null)
            {
                clsEmpleados empleadoAEditar = (clsEmpleados)dtgEmpleados.CurrentRow.DataBoundItem;

                frmAgregarEmpleado frmEditar = new frmAgregarEmpleado(empleadoAEditar);

                frmEditar.ShowDialog();

                CargarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para editar.");
            }
        }

        /// <summary>
        /// Maneja el clic del botón Agregar Empleado.
        /// Crea una nueva instancia de frmAgregarEmpleado, oculta la forma actual,
        /// muestra la nueva forma y la vuelve a mostrar al cerrarse.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado frmAEmp = new frmAgregarEmpleado();
            this.Hide();
            frmAEmp.ShowDialog();
            frmAEmp.Focus();
            CargarGrid(); 
            this.Show();
            
        }
    }
}