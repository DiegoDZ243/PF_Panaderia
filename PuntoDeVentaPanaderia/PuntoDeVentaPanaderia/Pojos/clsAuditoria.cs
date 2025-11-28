using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsAuditoria
    {
        public string nombre { get; set; }

        public string cambio { get; set; }
        public string usuario { get; set; }
        public decimal precioAnterior { get; set; }
        public decimal precioNuevo { get; set; }
        public DateTime fecha { get; set; }

        public clsAuditoria() { }

    }
}
