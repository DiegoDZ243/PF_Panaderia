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

namespace PuntoDeVentaPanaderia.ControlesUsuario
{
    public partial class cuPanItem : UserControl
    {
        private clsPanes infoPan;
        public cuPanItem(clsPanes pan)
        {
            this.infoPan = pan;
            InitializeComponent();
        }

        public PictureBox Imagen
        {
            get
            {
                return pcbPan;
            }
        }
        public clsPanes getInfoPan()
        {
            return infoPan;
        }

        private void cuPanItem_Load(object sender, EventArgs e)
        {
            lblNombre.Text = infoPan.nombre;
            lblStock.Text ="Stock: "+infoPan.stock;
            lblPrecio.Text = infoPan.precio.ToString("C"); //Formato moneda apa
            lblNombre.Location = new Point((this.ClientSize.Width - lblNombre.Width) / 2, lblNombre.Location.Y);
            lblPrecio.Location = new Point((this.ClientSize.Width - lblPrecio.Width) / 7, lblPrecio.Location.Y);
            lblStock.Location = new Point(5*(this.ClientSize.Width - lblPrecio.Width) / 7, lblPrecio.Location.Y);
        }

        private void pcbPan_Click(object sender, EventArgs e)
        {

        }
    }
}
