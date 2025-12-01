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

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrid();
            ConfigurarGrid();
        }

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

        private void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            frmAgregarEmpleado frmAEmp = new frmAgregarEmpleado();
            this.Hide();
            frmAEmp.ShowDialog();
            frmAEmp.Focus();
            this.Show();
        }
    }
}