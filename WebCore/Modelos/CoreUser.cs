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
            string perfil = "";
            switch (TipoPerfil)
            {
                case 1:
                    perfil = "Administrativo";
                    break;

                case 2:
                    perfil = "Mantenimiento";
                    break;

                case 3:
                    perfil = "Lector";
                    break;

                default:
                    break;
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************** Usuario **************");
            Console.WriteLine("Codigo: " + Codigo);
            Console.WriteLine("Perfil: " + perfil);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Fecha: " + DateTime.Now.ToString());
            Console.WriteLine("*************************************\n");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }
}