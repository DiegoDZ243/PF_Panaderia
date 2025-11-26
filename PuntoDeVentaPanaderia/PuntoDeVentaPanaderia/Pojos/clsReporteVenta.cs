using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsReporteVenta
    {
        public int clave {  get; set; }
        public string nombre { get; set; }
        public int unidades { get; set; }
        public decimal monto { get; set; }  

        public clsReporteVenta() { }

    }
}
