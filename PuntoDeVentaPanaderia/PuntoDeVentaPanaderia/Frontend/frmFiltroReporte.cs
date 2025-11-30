using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.Controles;
using PuntoDeVentaPanaderia.Pojos;

namespace PuntoDeVentaPanaderia.Frontend
{
    public partial class frmFiltroReporte : Form
    {
        public frmFiltroReporte()
        {
            InitializeComponent();
        }

        private void agregarImagenes()
        {
            string root = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            //Sufijo que se agrega
            string carpetaImagenes = Path.Combine(root, "Imagenes");

        }

        private void frmFiltroReporte_Load(object sender, EventArgs e)
        {
            clsDaoPanaderia dao= new clsDaoPanaderia();
            List<clsPanes> panes=dao.obtenerPanes();
            string root = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
            //Sufijo que se agrega
            string carpetaImagenes = Path.Combine(root, "Imagenes");
            foreach (clsPanes p in panes)
            {
                ctrlSeleccionarProducto control= new ctrlSeleccionarProducto(p);
                string img = Path.Combine(carpetaImagenes, p.direccionImg);
                control.Imagen.Image = Image.FromFile(img); 
                flpPanes.Controls.Add(control);

            }

        }
    }
}
