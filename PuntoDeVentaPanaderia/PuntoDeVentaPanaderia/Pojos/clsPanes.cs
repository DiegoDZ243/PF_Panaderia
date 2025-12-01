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
        
        public bool descontinuado { get; set; }
        public clsPanes() { }

        //Constructor creado solo con el proposito de usar el método Contains()
        //Solo se usa de manera temporal y no se emplea para crear objetos que se emeplearán o guardarán
        //en la base de datos.
        public clsPanes(int idPan)
        {
            this.idPan = idPan;
        }

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

        //Se sobreescribió para poder usar el método Contains() de la clase List<>
        //Sirve para buscar un objeto de tipo clsPan en una lista con un idPan igual al objeto a buscar
        public override bool Equals(object objeto)
        {
            if (objeto is clsPanes otro)
                return this.idPan == otro.idPan;

            return false;
        }

        public override int GetHashCode()
        {
            return idPan.GetHashCode();
        }
    }
}
