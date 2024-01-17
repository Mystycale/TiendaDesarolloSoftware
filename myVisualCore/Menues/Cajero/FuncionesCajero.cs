using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVisualCore.Menues.Producto
{
    internal class FuncionesCajero
    {
        static public void MostrarCajeros()
        {
            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.CAJERODataTable myCAJERPDataTable = client.SelectCajeros();

            string[] encabezado = new string[] { "CODIGO", "CEDULA", "NOMBRE", "APELLIDO", "TELEFONO", "DIRECCION" };

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n [  C A J E R O  ]\n");

            Console.WriteLine($" | {encabezado[0].PadRight(10).PadLeft(5)} | {encabezado[1].PadRight(12).PadLeft(5)} | {encabezado[2].PadRight(30).PadLeft(5)} | {encabezado[3].PadRight(30).PadLeft(5)} | {encabezado[4].PadRight(12).PadLeft(5)} | {encabezado[5].PadLeft(5)}");

            Console.ForegroundColor = ConsoleColor.White;


            foreach (var item in myCAJERPDataTable)
            {
                Console.WriteLine($" | {item.cjr_codigo.PadRight(10).PadLeft(5)} | {item.cjr_cedula.PadRight(12).PadLeft(5)} | {item.cjr_nombre.PadRight(30).PadLeft(5)} | {item.cjr_apellido.PadRight(30).PadLeft(5)} | {item.cjr_telefono.PadRight(12).PadLeft(5)} | {item.cjr_direccion.PadLeft(5)}");
            }
            Console.ReadKey();
        }
    }
}
