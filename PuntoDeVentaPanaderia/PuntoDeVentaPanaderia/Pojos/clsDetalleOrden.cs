using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsDetalleOrden
    {
        public int idPan {  get; set; }
        public int idOrden { get; set; }
    
        public int unidades { get; set; }
        public decimal precio { get; set; }

        public clsDetalleOrden() { }
        public clsDetalleOrden(int idPan, int idOrden, int unidades, decimal precio)
        {
            this.idPan = idPan;
            this.idOrden = idOrden;
            this.unidades = unidades;
            this.precio = precio;
        }
    }
}
