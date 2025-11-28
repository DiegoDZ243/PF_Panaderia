using PuntoDeVentaPanaderia.Backend;
using PuntoDeVentaPanaderia.Pojos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVentaPanaderia
{
    public partial class Form1 : Form
    {
        List<clsPanes> panes= new List<clsPanes>();
        int idEmpleado=1; 
        public Form1()
        {

            InitializeComponent();
            clsDaoPanaderia dao = new clsDaoPanaderia();
            gridPrueba.Rows.Clear();
            panes= dao.obtenerPanes();
            gridPrueba.DataSource = dao.obtenerAuditorias(); 
            seleccionaImg(); 
            
        }

        /// <summary>
        /// Permite seleccionar una imagen en el sistema donde se 
        /// ejecuta el programa y hacer una copia en el archivo del programa. Esto permite
        /// recuperar la imagen facilmente.
        /// --Nota: Hacer solo el file.copy() hasta que se confirme que esa será la imagen del pan.
        /// </summary>
        private void seleccionaImg()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaOrigen = openFileDialog.FileName;
                    string rutaDestino = "panesImg/" + Path.GetFileName(rutaOrigen);
                    if (!File.Exists(rutaDestino))
                    {
                        File.Copy(rutaOrigen, rutaDestino);
                    }
                    
                }
            }
        }

        private string CalcularSHA256(string input)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sb = new StringBuilder();

                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsDaoPanaderia dao=new clsDaoPanaderia();
            clsEmpleados empleado = dao.autentificarEmpleado(txtUsuario.Text,CalcularSHA256(txtPass.Text));
            if (empleado!=null)
            {
                MessageBox.Show("Bienvenido");
            }
            else
            {
                MessageBox.Show("Su usuario o contraseña son incorrectos");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //clsDetalleOrden detalle=new clsDetalleOrden();
            //detalle.idPan=int.Parse(txtProductoId.Text);
            //detalle.unidades= int.Parse(txtCantidad.Text);
            //panes.Add(detalle); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //clsDaoPanaderia dao= new clsDaoPanaderia();
            //if (dao.registrarOrden(panes,idEmpleado))
            //{
            //    MessageBox.Show("Se registro la orden"); 
            //}
            //else
            //{
            //    MessageBox.Show("No se registro"); 
            //}
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            clsDaoPanaderia dao =new clsDaoPanaderia();
            clsPanes pan = panes[Int32.Parse(txtIdProducto.Text.Trim()) - 1];
            pan.precio=Decimal.Parse(txtActualizaPrecio.Text.Trim());
            dao.actualizarPan(pan, 1); 
        }
    }
}