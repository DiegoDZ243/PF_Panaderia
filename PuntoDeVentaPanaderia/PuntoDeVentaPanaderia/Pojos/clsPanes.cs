using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsPanes
    {
        public int idPan { get; set; }
        public string nombre { get; set; }
        public string descripcion {  get; set; }
        public decimal precio { get; set; }
        public int stock {  get; set; }
        public string direccionImg { get; set; }
        public string categoria { get; set; }

        public clsPanes() { }

        public clsPanes(int idPan, string nombre, string descripcion, decimal precio,
            int stock, string direccionImg, string categoria)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.direccionImg = direccionImg;
            this.categoria = categoria;
        }
    }
}
