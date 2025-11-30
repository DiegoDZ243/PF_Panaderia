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
    /// <summary>
    /// Control personalizado que se empleará para elegir un pan para la 
    /// generación del reporte de ventas.
    /// </summary>
    public partial class cuElegirPan : UserControl
    {
        private clsPanes infoPan; 
        public cuElegirPan(clsPanes pan)
        {
            this.infoPan = pan;
            
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

        public CheckBox CajaCheck
        {
            get
            {
                return chkSeleccionar;
            }
        }

        public clsPanes getInfoPan()
        {
            return infoPan;
        }

        private void cuElegirPan_Load(object sender, EventArgs e)
        {
            lblNombre.Text = infoPan.nombre;
            lblNombre.Location = new Point((this.ClientSize.Width - lblNombre.Width) / 2, lblNombre.Location.Y); 
        }
    }
}
