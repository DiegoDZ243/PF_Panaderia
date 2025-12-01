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
    public partial class frmFiltrosReporte2 : Form
    {
        private List<clsPanes> panesSeleccionados=new List<clsPanes>(); 
        public frmFiltrosReporte2()
        {
            InitializeComponent();
        }

        private void frmFiltrosReporte2_Load(object sender, EventArgs e)
        {
            clsDaoPanaderia dao = new clsDaoPanaderia();
            List<clsPanes> panes = dao.obtenerPanes();

            try
            {
                foreach (clsPanes pan in panes)
                {
                    cuElegirPan control = new cuElegirPan(pan);
                    control.Imagen.Image = Image.FromFile(dao.GuardarImagenEnProyecto(pan.direccionImg));
                    flpPanes.Controls.Add(control);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            //aplicarColores(); 
            AplicarEstilo_Azul();
            lblTitulo.Location=new Point((this.ClientSize.Width-lblTitulo.Width)/2,lblTitulo.Location.Y);
            btnGenerarReporte.Location = new Point((this.ClientSize.Width - btnGenerarReporte.Width) / 2, btnGenerarReporte.Location.Y);
            pnlMain.Location=new Point((this.ClientSize.Width - pnlMain.Width) / 2, pnlMain.Location.Y);
            chkSeleccionarTodos.Location=new Point(pnlMain.Location.X+pnlMain.Width - chkSeleccionarTodos.Width-70,flpPanes.Location.Y-40);
            dtpMes1.Location=new Point((pnlMain.Width-dtpMes1.Width)/4,dtpMes1.Location.Y);
            dtpMes2.Location = new Point(3*(pnlMain.Width - dtpMes2.Width) / 4, dtpMes1.Location.Y);
            lblMes1.Location = new Point();
            lblMes2.Location = new Point();
            lblMes1.Location = new Point(
                dtpMes1.Left + (dtpMes1.Width - lblMes1.Width) / 2,   
                dtpMes1.Top - lblMes1.Height - 5                      
            );

            lblMes2.Location = new Point(
                dtpMes2.Left + (dtpMes2.Width - lblMes2.Width) / 2,   
                dtpMes2.Top - lblMes2.Height - 5                      
            );
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionarTodos.Checked)
            {
                foreach(Control ctrl in flpPanes.Controls)
                {
                    cuElegirPan control=(cuElegirPan)ctrl;
                    control.CajaCheck.Checked = true;
                }
            }
            else
            {
                foreach (Control ctrl in flpPanes.Controls)
                {
                    cuElegirPan control = (cuElegirPan)ctrl;
                    control.CajaCheck.Checked = false;
                }
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            
            foreach(Control ctrl in flpPanes.Controls)
            {
                cuElegirPan control = (cuElegirPan)ctrl;
                if (control.CajaCheck.Checked)
                {
                    panesSeleccionados.Add(control.getInfoPan()); 
                }
            }

            if (panesSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un pan", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmTablaReporte2 frm = new frmTablaReporte2(dtpMes1.Value,dtpMes2.Value, panesSeleccionados);
            this.Hide(); 
            frm.ShowDialog();
            frm.Focus();
            this.Show();
            panesSeleccionados.Clear();
        }


        private void AplicarEstilo_Azul()
        {
            Color formColor = Color.FromArgb(210, 225, 240);       // Fondo form
            Color flowColor = Color.FromArgb(186, 209, 230);       // FlowLayoutPanel
            Color cardColor = Color.FromArgb(150, 170, 190);       // Panel/Card
            Color imgColor = Color.FromArgb(225, 235, 245);        // Fondo imagen
            Color textColor = Color.FromArgb(30, 45, 60);          // Texto principal
            Color textSec = Color.FromArgb(70, 90, 110);           // Texto secundario
            Color botonColor = Color.FromArgb(40, 85, 140);        // Botón
            Color botonHover = Color.FromArgb(25, 60, 110);        // Hover

            this.BackColor = formColor;
            this.Font = new Font("Segoe UI", 11, FontStyle.Regular);


            flpPanes.BackColor = flowColor;
            flpPanes.Padding = new Padding(20);
            flpPanes.AutoScroll = true;
            flpPanes.WrapContents = true;     // Mantener tarjetas en filas
            flpPanes.AutoSize = false;
            pnlMain.Width =this.ClientSize.Width-100;
            pnlMain.Height = this.ClientSize.Height - 180;
            flpPanes.Size=new Size(this.ClientSize.Width - 100, flpPanes.Width); 

            foreach (Control ctrl in flpPanes.Controls)
            {
                if (ctrl is cuElegirPan card)
                {
                    // Tamaño fijo para evitar estiramiento

                    card.BackColor = cardColor;
                    card.Padding = new Padding(10);
                    card.BorderStyle = BorderStyle.None;
                    card.setTamanosDefault(); 
                }
            }

            lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitulo.ForeColor = textColor;
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.FlatAppearance.BorderSize = 0;
            btnGenerarReporte.BackColor = botonColor;
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnGenerarReporte.Height = 45;
            btnGenerarReporte.Width = 180;
            btnGenerarReporte.Cursor = Cursors.Hand;


            btnGenerarReporte.MouseEnter += (s, e) =>
            {
                btnGenerarReporte.BackColor = botonHover;
            };
            btnGenerarReporte.MouseLeave += (s, e) =>
            {
                btnGenerarReporte.BackColor = botonColor;
            };
        }


    }
}
