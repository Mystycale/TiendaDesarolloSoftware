﻿//Creacion de todas las tablas
/*
PRODUCTO creada
CAJERO crada
SERVICIO creada
CLIENTE creada
FACTURA creada
FCT_PROD creada
FCT_SERV creada
-
PERFIL creada
USUARIO creada
configurando estado default 1 de todas las tablas
-
Creacion del MyCoreDataSet
Ingreso de la tabla CAJERO al dataset
Creacion del WebMethod IngresarCajero
-
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VisualCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServicioDelCore.CoreWebServiceSoapClient cliente = new ServicioDelCore.CoreWebServiceSoapClient(); 

            string respuesta = cliente.HelloWorld(); //Helloworld es uno de los metodos del servicio web
            //Recuerda que cada vez que se agregues un nuevo metodo en el servicio web, se debe...
            //dar click derecho sobre "ServicioDelCore"(esta adentro de "Connected Services en visualCore") y...
            //Click en actualizar referencia del servicio 

            Console.WriteLine(respuesta);
        }
    }
}