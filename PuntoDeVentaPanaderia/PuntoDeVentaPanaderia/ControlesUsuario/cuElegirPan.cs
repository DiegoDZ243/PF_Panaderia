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

        public void setTamanosDefault()
        {
            
            this.Height=227;
            this.Width = 196;
            this.pcbPan.Height = 150;
            this.pcbPan.Width = 150;
            this.pcbPan.Location = new Point((this.ClientSize.Width - pcbPan.Width) / 2, 39);
            this.chkSeleccionar.Location=new Point((this.ClientSize.Width - chkSeleccionar.Width)/2, 195);
            lblNombre.Location = new Point((this.ClientSize.Width - lblNombre.Width) / 2, 11);
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
