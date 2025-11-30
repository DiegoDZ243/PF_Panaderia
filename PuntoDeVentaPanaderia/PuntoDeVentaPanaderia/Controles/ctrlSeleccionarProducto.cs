using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVentaPanaderia.Pojos; 

namespace PuntoDeVentaPanaderia.Controles
{
    public partial class ctrlSeleccionarProducto : UserControl
    {
        public clsPanes pan {  get; set; }
        public ctrlSeleccionarProducto()
        {
            InitializeComponent();
        }

        public ctrlSeleccionarProducto(clsPanes pan)
        {
            this.pan = pan;
            InitializeComponent();
        }
        public bool getSeleccion()
        {
            return chkSeleccionar.Checked; 
        }

        public PictureBox Imagen
        {
            get
            {
                return pcbPan; 
            }
        }

        private void ctrlSeleccionarProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
