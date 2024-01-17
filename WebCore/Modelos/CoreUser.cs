using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class CoreUser
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoPerfil { get; set; }

        public void Mostrar()
        {
            Console.WriteLine("************** Usuario **************");
            Console.WriteLine("Codigo: " + Codigo);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Fecha: " + DateTime.Now.ToString());
            Console.WriteLine("*************************************\n");
        }
    }
}