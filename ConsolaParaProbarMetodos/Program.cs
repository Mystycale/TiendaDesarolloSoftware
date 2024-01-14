using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaParaProbarMetodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServicioCapaSoapClient metodos = new ServiceReference1.ServicioCapaSoapClient();

            //string respuesta = metodos.HelloWorld(); //llamando al metodo hello world
            //Console.WriteLine(respuesta);
            metodos.insertarCajero("CAJ011", "0010001", "Carlos", "Perez", "80944421", "Alli");

            //recordar que cuando se agregue o se actualice un metodo web
            //se debe de dar click derecho sobre las serviceReference1 (adentro de connected services) y...
            //Click en actualizar referencias

        }
    }
}
