using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsReporteVentaMes
    {
        public int clave {  get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public decimal ventasMes1 { get; set; }
        public decimal ventasMes2 { get; set; }

        public clsReporteVentaMes()
        {

        }


    }
}
