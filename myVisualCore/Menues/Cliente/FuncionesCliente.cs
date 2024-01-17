using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVisualCore.Menues.Producto
{
    internal class FuncionesCliente
    {
        static public void MostrarClientes()
        {
            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.CLIENTEDataTable myCLIENTEDataTable = client.SelectClientes();

            string[] encabezado = new string[] { "CODIGO",                  "CEDULA",                                   "NOMBRE",                               "APELLIDO",                                 "TELEFONO",                                             "SALDO",                            "DIRECCION" };

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n\n [  C L I E N T E S  ]\n");

            Console.WriteLine($" | {encabezado[0].PadRight(10).PadLeft(5)} | {encabezado[1].PadRight(12).PadLeft(5)} | {encabezado[2].PadRight(30).PadLeft(5)} | {encabezado[3].PadRight(30).PadLeft(5)} | {encabezado[4].PadRight(12).PadLeft(5)} | {encabezado[5].PadRight(10).PadLeft(5)} | {encabezado[6].PadLeft(5)}");

            Console.ForegroundColor = ConsoleColor.White;


            foreach (var item in myCLIENTEDataTable)
            {
                Console.WriteLine($" | {item.clt_codigo.PadRight(10).PadLeft(5)} | {item.clt_cedula.PadRight(12).PadLeft(5)} | {item.clt_nombre.PadRight(30).PadLeft(5)} | {item.clt_apellido.PadRight(30).PadLeft(5)} | {item.clt_telefono.PadRight(12).PadLeft(5)} | {item.clt_saldo.ToString().PadRight(10).PadLeft(5)} | {item.clt_direccion.PadLeft(5)}");
            }
            Console.ReadKey();

        }
    }
}
