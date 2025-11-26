using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVentaPanaderia.Pojos
{
    public class clsEmpleados
    {
        public int idEmpleado {get;set;}
        public string nombre { get;set;}
        public string apellidos { get;set;}
        public string usuario { get;set;}
        public string contrasena { get; set;}
        public string telefono { get;set;}

        public clsEmpleados() { }
        public clsEmpleados(int idEmpleado, string nombre, string apellidos, string usuario,
            string telefono)
        {
            this.idEmpleado=idEmpleado; 
            this.nombre=nombre;
            this.apellidos=apellidos;
            this.usuario=usuario;
            this.telefono=telefono;
        }
    }
}
