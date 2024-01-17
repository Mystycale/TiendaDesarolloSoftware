using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVisualCore.Menues.Servicio
{
    internal class FuncionesServicio
    {
        static public void MostrarServicios()
        {
            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.SERVICIODataTable mySERVICIODataTable = client.SelectServicios();

            string[] encabezado = new string[] { "CODIGO", "NOMBRE", "PRECIO", "DESCRIPCION" };

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n [  S E R V I C I O S  ]\n");

            Console.WriteLine($" | {encabezado[0].PadRight(10).PadLeft(5)} | {encabezado[1].PadRight(30).PadLeft(5)} | {encabezado[2].PadRight(9).PadLeft(5)} | {encabezado[3].PadLeft(5)}");

            Console.ForegroundColor = ConsoleColor.White;


            foreach (var item in mySERVICIODataTable)
            {
                Console.WriteLine($" | {item.serv_codigo.PadRight(8).PadLeft(5)} | {item.serv_nombre.PadRight(30).PadLeft(5)} | {item.serv_precio.ToString().PadRight(9).PadLeft(5)} | {item.serv_desc.PadLeft(5)}");
            }
            Console.ReadKey();
        }

    }
}
