using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myVisualCore.Menues.Producto
{
    internal class FuncionesProducto
    {
        static public void MostrarProductos() 
        {
            ServicioDelCore.CoreWebServiceSoapClient client = new ServicioDelCore.CoreWebServiceSoapClient();

            ServicioDelCore.WebCoreDataSet.PRODUCTODataTable myPRODUCTODataTable = client.SelectProductos();

            string[] encabezado = new string[] { "CODIGO", "NOMBRE", "PRECIO", "STOCK", "DESCRIPCION" };


            Console.WriteLine("\n\n [  P R O D U C T O S  ]\n");

            Console.WriteLine($" | {encabezado[0].PadRight(10).PadLeft(5)} | {encabezado[1].PadRight(15).PadLeft(5)} | {encabezado[2].PadRight(9).PadLeft(5)} | {encabezado[3].PadRight(5).PadLeft(5)} | {encabezado[4].PadLeft(5)}");

            foreach (var item in myPRODUCTODataTable)
            {
                Console.WriteLine($" | {item.prod_codigo.PadRight(8).PadLeft(5)} | {item.prod_nombre.PadRight(15).PadLeft(5)} | {item.prod_precio.ToString().PadRight(9).PadLeft(5)} | {item.prod_stock.ToString().PadRight(5).PadLeft(5)} | {item.prod_desc.PadLeft(5)}");
            }
            Console.ReadKey();

        }
    }
}
