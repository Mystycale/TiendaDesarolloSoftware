using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaParaProbarMetodos
{
    internal class Program
    {
        //clase cajero para poder obtener los datos
        public class Cajero
        {
            public string codigo { get; set; }
            public string cedula { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string telefono { get; set; }
            public string direccion { get; set; }
        }

        static async Task Main(string[] args)
        {
            ServiceReference1.ServicioCapaSoapClient metodos = new ServiceReference1.ServicioCapaSoapClient();


            while (true)
            {

                metodos.VerificarCajerosIntroducidosACore(); //verifica si todos los cajeros han sido ingresados a core
                metodos.VerificarClientesIntroducidosACore(); //verifica si todos lo clientes han sido ingresados a core
                metodos.VerificarFacturaIntroducidosACore(); //"" '"" "" """ Facturas
                metodos.VerificarFacturaProductoIntroducidosACore(); // " ' "" " factura_preducto
                metodos.VerificarFacturaServicioIntroducidosACore(); // "" "" "" factura_servicio
                Console.WriteLine("Ejecutado a las: " + DateTime.Now);

                // Espera 5 minutos
                await Task.Delay(TimeSpan.FromMinutes(5));
            }
            //string respuesta = metodos.HelloWorld(); //llamando al metodo hello world
            //Console.WriteLine(respuesta);

            //insertar datos a la tabla cajero
            //metodos.insertarCajero("CAJ011", "0010001", "Carlos", "Perez", "80944421", "Alli");

            //recordar que cuando se agregue o se actualice un metodo web
            //se debe de dar click derecho sobre las serviceReference1 (adentro de connected services) y...
            //Click en actualizar referencias



            //Forma de obtener los cajeros, arriba se crea una clases que es la misma que se usa en el webcore
            //        List<Cajero> cajeros = metodos.ObtenerCajero()
            //.Select(c => new Cajero
            //{
            //    codigo = c.codigo,
            //    cedula = c.cedula,
            //    nombre = c.nombre,
            //    apellido = c.apellido,
            //    telefono = c.telefono,
            //    direccion = c.direccion
            //})
            //.ToList();

            //        foreach (var cajero in cajeros)
            //        {
            //            Console.WriteLine(cajero.codigo + " " + cajero.nombre);
            //        }



        }
    }
}
