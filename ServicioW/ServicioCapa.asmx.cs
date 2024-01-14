using ServicioW.DataSetCapaTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services;

namespace ServicioW
{
    /// <summary>
    /// Descripción breve de ServicioCapa
    /// </summary>
    [WebService(Namespace = "http://intec.edu.do")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]

    public class ServicioCapa : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        CAJEROTableAdapter adaptarCajero = new CAJEROTableAdapter(); //adaptador de tabla cajero
        CLIENTETableAdapter adaptarCliente = new CLIENTETableAdapter(); //adaptador de tabla cliente
        SERVICIOTableAdapter adaptarServicio = new SERVICIOTableAdapter(); //adaptador de tabla Servicio
        FACTURATableAdapter adaptarFactura = new FACTURATableAdapter(); //adaptador de tabla factura
        PRODUCTOTableAdapter adaptarProducto = new PRODUCTOTableAdapter(); //adaptador de tabla producto
        FCT_PRODTableAdapter adaptarFCTProducto = new FCT_PRODTableAdapter(); //Adaptador de tabla  FCT_PROD
        FCT_SERVTableAdapter adaptarFCTServicio = new FCT_SERVTableAdapter(); //Adaptador de tabla FCT_Serv

        [WebMethod]
        public string HelloWorld()
        {
            log.Info("Prueba"); //Los log van siempre antes del return
            //log.Debug("");
            //log.Error("");
            return "Hola a todos";
            
        }

        //Insertar Cajero
        [WebMethod]
        public void insertarCajero(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion)
        {
            

            log.Debug("Intentando insertar cajero...");
            try
            {
                //El parametro estado representara si se ha introducido el dato al Core, en este caso, estado=1 significa que si
                adaptarCajero.InsertarCajero(codigo, cedula, nombre, apellido, telefono, direccion, 1);
                log.Info("Se ha insertado un nuevo cajero con codigo:" + codigo);
            }
            catch(Exception ex){
                log.Error("Error, no se ha podido ingresar el cajero...Exception:" + ex.Message);
            }
            
            

        }


        //Insertar Cliente
        [WebMethod]
        public void insertarCliente(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion,decimal saldo)
        {
            log.Debug("Intentando insertar cliente...");
            try
            {
                
                adaptarCliente.InsertarCliente(codigo, cedula, nombre, apellido, telefono, direccion, saldo, 1);
                log.Info("Se ha insertado un nuevo cliente con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el cliente...Exception:" + ex.Message);
            }
            

        }

        //Insertar servicio
        [WebMethod]
        public void insertarServicio(string codigo, string nombre, string descripcion, decimal precio)
        {
            log.Debug("Intentando insertar Servicio...");
            try
            {
                
                adaptarServicio.InsertarServicio(codigo, nombre, descripcion, precio, 1);
                log.Info("Se ha insertado un nuevo Servicio con codigo:" + codigo);
            }
            catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el servicio...Exception:" + ex.Message);
            }
            

        }

        //Insertar factura
        [WebMethod]
        public void insertarFactura(string codigo, bool bit, DateTime fecha, decimal total, int metodoPago, string codigoCajero,string codigoCliente)
        {
            log.Debug("Intentando insertar Factura...");
            try
            { 
                adaptarFactura.InsertarFactura(codigo, bit, fecha, total, metodoPago, codigoCajero, codigoCliente, 1);
                log.Info("Se ha insertado una nueva Factura con codigo:" + codigo);
            }
            catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura...Exception:" + ex.Message);
            }

        }

        //Insertar producto
        [WebMethod]
        public void insertarProducto(string codigo, string nombre, string descripcion, int stock, decimal precio)
        {
            log.Debug("Intentando insertar Producto...");
            try
            {
                adaptarProducto.InsertarProducto(codigo, nombre, descripcion, stock, precio, 1);
                log.Info("Se ha insertado un nuevo Producto con codigo:" + codigo);
            }
            catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el producto...Exception:" + ex.Message);
            }

        }


        //Insertar factura_producto
        [WebMethod]
        public void insertarFacturaProducto(string codigoProducto, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Producto...");
            try
            {
                adaptarFCTProducto.InsertarFCTProducto(codigoProducto, codigoFactura, cantidad, precio, total, 1);
                log.Info("Se ha insertado un nuevo Factura_Producto con codigo producto:" + codigoProducto + " Y codigo factura:"+ codigoFactura);
            }
            catch(Exception ex){
                log.Error("Error, no se ha podido ingresar la factura_producto...Exception:" + ex.Message);
            }

        }

        //Insertar factura_servicio
        [WebMethod]
        public void insertarFacturaServicio(string codigoServicio, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Servcio...");
            try
            {
                log.Info("Se ha insertado un nuevo Factura_Producto con codigo servicio:" + codigoServicio + " Y codigo factura:" + codigoFactura);
                adaptarFCTServicio.InsertarFCTServicio(codigoServicio, codigoFactura, cantidad, precio, total,1);
            }catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura_servicio...Exception:" + ex.Message);
            }

        }


    }
}
