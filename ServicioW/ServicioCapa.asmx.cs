using ServicioW.DataSetCapaTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI.WebControls;

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

        #region clases
        //// Clase para retornar los cajeros
        //public class Cajero
        //{
        //    public string codigo { get; set; }
        //    public string cedula { get; set; }
        //    public string nombre { get; set; }
        //    public string apellido { get; set; }
        //    public string telefono { get; set; }
        //    public string direccion { get; set; }
        //}

        // Clase para retornar los clientes
        public class Cliente
        {
            public string codigo { get; set; }
            public string cedula { get; set; }
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string telefono { get; set; }
            public string direccion { get; set; }
            public decimal saldo { get; set; }
        }

        //Clase para retornar los productos

        public class Producto
        {
            public string codigo { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public int stock { get; set; }
            public decimal precio { get; set; }
        }

        //Clase para retornar los servicios

        public class Servicio
        {
            public string codigo { get; set; }
            public string nombre { get; set; }
            public string descripcion { get; set; }
            public decimal precio { get; set; }
        }

        
        //clase para las facturas
        public class Factura
        {
            public string codigo { get; set; }
            public bool cotizacion { get; set; }
            public DateTime fecha { get; set; }
            public decimal total { get; set; }
            public int metodoPago { get; set; }
            public string cajeroCodigo { get; set; }
            public string clienteCodigo { get; set; }
        }


        //clase para factura_producto

        public class FacturaProducto
        {
            public string codigoFactura { get; set; }
            public string codigoProducto { get; set; }
            public int cantidad { get; set; }
            public decimal precio { get; set; }
            public decimal total { get; set; }
        }

        //clase para factura_servicio

        public class FacturaServicio
        {
            public string codigoFactura { get; set; }
            public string codigoServicio { get; set; }
            public int cantidad { get; set; }
            public decimal precio { get; set; }
            public decimal total { get; set; }
        }

        #endregion




        //-----------------------------------
        // Revisar datos sin ingresar al Core
        //-----------------------------------

        #region Revisar datos sin ingresar

        //Metodo para ver si algun cajero no esta ingresado en el Core atravez de su estado
        [WebMethod]
        public void VerificarCajerosIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core (cajeros)...");
            try
            {
                log.Debug("Buscando cajeros sin insertar en el Core....");
                var dt = adaptarCajero.GetDataBy1(); //almacena los datos obteneidos del select

                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigo = Convert.ToString(row["cjr_codigo"]);
                    string cedula = Convert.ToString(row["cjr_cedula"]);
                    string nombre = Convert.ToString(row["cjr_nombre"]);
                    string apellido = Convert.ToString(row["cjr_apellido"]);
                    string telefono = Convert.ToString(row["cjr_telefono"]);
                    string direccion = Convert.ToString(row["cjr_direccion"]);
                    if (Convert.ToInt32(row["cjr_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Cajero insertado al Core...Codigo: " + codigo);
                            adaptarCajero.ActualizarEstadoCjr(1, codigo);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener cajeros para insertar en el Core.... Exception: " + ex.Message);
            }
        }



        //metodo para ver si algun cliente no esta insertado en el core

        [WebMethod]
        public void VerificarClientesIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core (clientes)...");
            try
            {
                log.Debug("Buscando clientes sin insertar en el Core....");
                var dt = adaptarCliente.GetDataBy1(); //almacena los datos obteneidos del select
                //--------------------------Actualizar desde aqui-------------------------
                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigo = Convert.ToString(row["clt_codigo"]);
                    string cedula = Convert.ToString(row["clt_cedula"]);
                    string nombre = Convert.ToString(row["clt_nombre"]);
                    string apellido = Convert.ToString(row["clt_apellido"]);
                    string telefono = Convert.ToString(row["clt_telefono"]);
                    string direccion = Convert.ToString(row["clt_direccion"]);
                    decimal saldo = Convert.ToDecimal(row["clt_saldo"]);
                    if (Convert.ToInt32(row["clt_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Cliente insertado al Core...Codigo: " + codigo);
                            adaptarCliente.ActualizarEstadoClt(1, codigo);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener cliente para insertar en el Core.... Exception: " + ex.Message);
            }
        }





        //metodo para ver si alguna factura no esta insertado en el core

        [WebMethod]
        public void VerificarFacturaIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core (facturas)...");
            try
            {
                log.Debug("Buscando facturas sin insertar en el Core....");
                var dt = adaptarFactura.GetDataBy1(); //almacena los datos obteneidos del select
                
                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigo = Convert.ToString(row["fct_codigo"]);
                    bool cotizacion = Convert.ToBoolean(row["fct_cotizacion"]);
                    DateTime fecha = Convert.ToDateTime(row["fct_fecha"]);
                    decimal total = Convert.ToDecimal(row["fct_total"]);
                    int metodoPago = Convert.ToInt32(row["fct_metodoPago"]);
                    string codigoCajero = Convert.ToString(row["fct_cjr_codigo"]);
                    decimal saldo = Convert.ToDecimal(row["fct_clt_codigo"]);
                    if (Convert.ToInt32(row["fct_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Factura insertada al Core...Codigo: " + codigo);
                            adaptarFactura.ActualizarEstadoFct(1, codigo);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener factura para insertar en el Core.... Exception: " + ex.Message);
            }
        }



        //metodo para ver si alguna factura_producto no esta insertado en el core

        [WebMethod]
        public void VerificarFacturaProductoIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core (factura_producto)...");
            try
            {
                log.Debug("Buscando factura_producto sin insertar en el Core....");
                var dt = adaptarFCTProducto.GetDataBy1(); //almacena los datos obteneidos del select

                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigoProducto = Convert.ToString(row["fp_prod_codigo"]);
                    string codigoFactura = Convert.ToString(row["fp_fct_codigo"]);
                    int cantidad = Convert.ToInt32(row["fp_cantidad"]);
                    decimal precio = Convert.ToDecimal(row["fp_precio_u"]);
                    decimal total = Convert.ToDecimal(row["fp_total"]);
                    if (Convert.ToInt32(row["fp_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Factura_prod insertada al Core...Codigo Producto: " + codigoProducto + " Codigo factura: " + codigoFactura);
                            adaptarFCTProducto.ActualizarEstadoFCTPROD(1, codigoProducto, codigoFactura);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener factura_producto para insertar en el Core.... Exception: " + ex.Message);
            }
        }




        //metodo para ver si alguna factura_servicio no esta insertado en el core

        [WebMethod]
        public void VerificarFacturaServicioIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core (factura_servicio)...");
            try
            {
                log.Debug("Buscando factura_servicio sin insertar en el Core....");
                var dt = adaptarFCTServicio.GetDataBy1(); //almacena los datos obteneidos del select

                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigoServicio = Convert.ToString(row["fs_serv_codigo"]);
                    string codigoFactura = Convert.ToString(row["fs_fct_codigo"]);
                    int cantidad = Convert.ToInt32(row["fs_cantidad"]);
                    decimal precio = Convert.ToDecimal(row["fs_precio_u"]);
                    decimal total = Convert.ToDecimal(row["fs_total"]);
                    if (Convert.ToInt32(row["fs_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Factura_serv insertada al Core...Codigo servicio: " + codigoServicio + " Codigo factura: " + codigoFactura);
                            adaptarFCTServicio.ActualizarEstadoFCTSERV(1, codigoServicio, codigoFactura);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex.Message);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener factura_servicio para insertar en el Core.... Exception: " + ex.Message);
            }
        }

        #endregion








        /*
        //Metodo para ver si algun producto no esta ingresado en el Core atravez de su estado
        [WebMethod]
        public void VerificarProductosIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core...");
            try
            {
                log.Debug("Buscando productos sin insertar en el Core....");
                var dt = adaptarProducto.GetDataBy1(); //almacena los datos obteneidos del select

                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigo = Convert.ToString(row["prod_codigo"]);
                    string nombre = Convert.ToString(row["prod_nombre"]);
                    string descripcion = Convert.ToString(row["prod_desc"]);
                    int stock = Convert.ToInt32(row["prod_stock"]);
                    decimal precio = Convert.ToDecimal(row["prod_precio"]);
                    if (Convert.ToInt32(row["prod_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Producto insertado al Core...");
                            adaptarProducto.ActualizarEstado(1, codigo);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex);
                        }

                    }

                }
            }
            catch(Exception ex)
            {
                log.Error("Error al intentar obtener productos para insertar en el Core.... Exception: "+ ex);
            }
        }



        //Buscar Servicios que no esten insertados en el Core
        
        [WebMethod]
        public void VerificarServiciosIntroducidosACore()
        {
            log.Debug("Se esta solicitando actualizar el Core...");
            try
            {
                log.Debug("Buscando servicios sin insertar en el Core....");
                var dt = adaptarServicio.GetDataBy1(); //almacena los datos obteneidos del select

                foreach (DataRow row in dt.Rows) //intera para obtener los datos
                {

                    string codigo = Convert.ToString(row["serv_codigo"]);
                    string nombre = Convert.ToString(row["serv_nombre"]);
                    string descripcion = Convert.ToString(row["serv_desc"]);
                    decimal precio = Convert.ToDecimal(row["serv_precio"]);

                    if (Convert.ToInt32(row["serv_estado"]) == 0)
                    {
                        try
                        {
                            //metodo para insertar al core
                            log.Info("Servicio insertado al Core...");
                            adaptarServicio.ActualizarEstadoSer(1, codigo);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error al intentar actualizar Core... Exception: " + ex);
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Error al intentar obtener productos para insertar en el Core.... Exception: " + ex);
            }
        }

        */





        [WebMethod]
        public string HelloWorld()
        {
            log.Info("Prueba"); //Los log van siempre antes del return
            //log.Debug("");
            //log.Error("");
            return "Hola a todos";
            
        }

        #region MetodosInsert
        //Insertar Cajero
        [WebMethod]
        public void insertarCajero(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion)
        {
            

            log.Debug("Intentando insertar cajero...");
            try
            {

                //El parametro estado representara si se ha introducido el dato al Core, en este caso, estado=1 significa que si
                //metodo para insertar al core--------
                
                log.Info("Se ha insertado un nuevo cajero con codigo:" + codigo);
                adaptarCajero.InsertarCajero(codigo, cedula, nombre, apellido, telefono, direccion, 1); //inserta a la capa
            }
            catch(Exception ex){
                log.Error("Error, no se ha podido ingresar el cajero a core...Exception:" + ex.Message);
                try
                {
                    log.Debug("Intentado insertar datos de cajero a capa de integracion...");
                    adaptarCajero.InsertarCajero(codigo, cedula, nombre, apellido, telefono, direccion, 1);
                    log.Info("Datos de cajero con codigo: " +codigo+ " insertados a la capa de integracion");
                }
                catch(Exception nex)
                {
                    log.Error("Error al intentar guardar datos... Exception: " +nex.Message);
                }
            }
            
            

        }


        //Insertar Cliente
        [WebMethod]
        public void insertarCliente(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion,decimal saldo)
        {
            log.Debug("Intentando insertar cliente...");
            try
            {
                //metodo core
                adaptarCliente.InsertarCliente(codigo, cedula, nombre, apellido, telefono, direccion, saldo, 1);
                log.Info("Se ha insertado un nuevo cliente con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el cliente...Exception:" + ex.Message);
                try
                {
                    log.Debug("Intentado insertar datos de cliente a capa de integracion...");
                    adaptarCliente.InsertarCliente(codigo, cedula, nombre, apellido, telefono, direccion, saldo, 1);
                    log.Info("Datos de cliente con codigo: " + codigo + " insertados a la capa de integracion");
                }
                catch (Exception nex)
                {
                    log.Error("Error al intentar guardar datos... Exception: " + nex.Message);
                }
            }
            

        }

        ////Insertar servicio
        //[WebMethod]
        //public void insertarServicio(string codigo, string nombre, string descripcion, decimal precio)
        //{
        //    log.Debug("Intentando insertar Servicio...");
        //    try
        //    {
                
        //        adaptarServicio.InsertarServicio(codigo, nombre, descripcion, precio, 1);
        //        log.Info("Se ha insertado un nuevo Servicio con codigo:" + codigo);
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Error("Error, no se ha podido ingresar el servicio...Exception:" + ex.Message);
        //    }
            

        //}

        //Insertar factura
        [WebMethod]
        public void insertarFactura(string codigo, bool bit, DateTime fecha, decimal total, int metodoPago, string codigoCajero,string codigoCliente)
        {
            log.Debug("Intentando insertar Factura...");
            try
            { 
                //metodo core
                adaptarFactura.InsertarFactura(codigo, bit, fecha, total, metodoPago, codigoCajero, codigoCliente, 1);
                log.Info("Se ha insertado una nueva Factura con codigo:" + codigo);
            }
            catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura...Exception:" + ex.Message);
                try
                {
                    log.Debug("Intentado insertar datos de factura a capa de integracion...");
                    adaptarFactura.InsertarFactura(codigo, bit, fecha, total, metodoPago, codigoCajero, codigoCliente, 1);
                    log.Info("Datos de factura con codigo: " + codigo + " insertados a la capa de integracion");
                }
                catch (Exception nex)
                {
                    log.Error("Error al intentar guardar datos... Exception: " + nex.Message);
                }
            }

        }

        ////Insertar producto
        //[WebMethod]
        //public void insertarProducto(string codigo, string nombre, string descripcion, int stock, decimal precio)
        //{
        //    log.Debug("Intentando insertar Producto...");
        //    try
        //    {
        //        adaptarProducto.InsertarProducto(codigo, nombre, descripcion, stock, precio, 1);
        //        log.Info("Se ha insertado un nuevo Producto con codigo:" + codigo);
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Error("Error, no se ha podido ingresar el producto...Exception:" + ex.Message);
        //    }

        //}


        //Insertar factura_producto
        [WebMethod]
        public void insertarFacturaProducto(string codigoProducto, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Producto...");
            try
            {
                //metodo core
                adaptarFCTProducto.InsertarFCTProducto(codigoProducto, codigoFactura, cantidad, precio, total, 1);
                log.Info("Se ha insertado un nuevo Factura_Producto con codigo producto:" + codigoProducto + " Y codigo factura:"+ codigoFactura);
            }
            catch(Exception ex){
                log.Error("Error, no se ha podido ingresar la factura_producto...Exception:" + ex.Message);
                try
                {
                    log.Debug("Intentado insertar datos de factura_producto a capa de integracion...");
                    adaptarFCTProducto.InsertarFCTProducto(codigoProducto, codigoFactura, cantidad, precio, total, 1);
                    log.Info("Datos de factura_producto con codigo factura: " + codigoFactura +" codigo producto: "+ codigoProducto +" insertados a la capa de integracion");
                }
                catch (Exception nex)
                {
                    log.Error("Error al intentar guardar datos... Exception: " + nex.Message);
                }
            }

        }

        //Insertar factura_servicio
        [WebMethod]
        public void insertarFacturaServicio(string codigoServicio, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Servcio...");
            try
            {
                log.Info("Se ha insertado un nuevo Factura_Servicio con codigo servicio:" + codigoServicio + " Y codigo factura:" + codigoFactura);
                adaptarFCTServicio.InsertarFCTServicio(codigoServicio, codigoFactura, cantidad, precio, total,1);
            }catch(Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura_servicio...Exception:" + ex.Message);
                try
                {
                    log.Debug("Intentado insertar datos de factura_servicio a capa de integracion...");
                    adaptarFCTServicio.InsertarFCTServicio(codigoServicio, codigoFactura, cantidad, precio, total, 1);
                    log.Info("Datos de factura_servicio con codigo factura: " + codigoFactura + " codigo seervicio: " + codigoServicio + " insertados a la capa de integracion");
                }
                catch (Exception nex)
                {
                    log.Error("Error al intentar guardar datos... Exception: " + nex.Message);
                }
            }

        }

        #endregion



        #region RetornarDatos
        //----------------
        //metodos con retorno
        //----------------



        ////Obtener cajero
        //[WebMethod]
        //public List<Cajero> ObtenerCajero()
        //{
        //    log.Debug("Se estan solicitando los cajeros...");
        //    var dt = adaptarCajero.GetDataBy1(); //almacena los datos obteneidos del select

        //    var cajeros = new List<Cajero>();

        //    foreach (DataRow row in dt.Rows) //intera para obtener los datos
        //    {
        //        var cajero = new Cajero
        //        {
        //            codigo = Convert.ToString(row["cjr_codigo"]),
        //            cedula = Convert.ToString(row["cjr_cedula"]),
        //            nombre = Convert.ToString(row["cjr_nombre"]),
        //            apellido = Convert.ToString(row["cjr_apellido"]),
        //            telefono = Convert.ToString(row["cjr_telefono"]),
        //            direccion = Convert.ToString(row["cjr_direccion"])
        //        };

        //        cajeros.Add(cajero);
        //    }

        //    log.Info("Datos de cajeros enviados");
        //    return cajeros;

        //}


        //Obtener clientes
        [WebMethod]
        public List<Cliente> ObtenerCliente()
        {
            log.Debug("Se estan solicitando los cajeros...");
            var dt = adaptarCajero.GetDataBy1(); //almacena los datos obteneidos del select

            var clientes = new List<Cliente>();

            foreach (DataRow row in dt.Rows) //intera para obtener los datos
            {
                var cliente = new Cliente
                {
                    codigo = Convert.ToString(row["clt_codigo"]),
                    cedula = Convert.ToString(row["clt_cedula"]),
                    nombre = Convert.ToString(row["clt_nombre"]),
                    apellido = Convert.ToString(row["clt_apellido"]),
                    telefono = Convert.ToString(row["clt_telefono"]),
                    direccion = Convert.ToString(row["clt_direccion"]),
                    saldo = Convert.ToDecimal(row["clt_saldo"])
                };

                clientes.Add(cliente);
            }

            log.Info("Datos de clientes enviados");
            return clientes;

        }




        
        //Obtener productos



        [WebMethod]
        public List<Producto> ObtenerProductos()
        {
            log.Debug("Se estan solicitando los productos...");
            var dt = adaptarProducto.GetDataBy1(); //almacena los datos obteneidos del select

            var productos = new List<Producto>();

            foreach (DataRow row in dt.Rows) //intera para obtener los datos
            {
                var cliente = new Producto
                {
                    codigo = Convert.ToString(row["prod_codigo"]),
                    nombre = Convert.ToString(row["prod_nombre"]),
                    descripcion = Convert.ToString(row["prod_desc"]),
                    stock = Convert.ToInt32(row["prod_stock"]),
                    precio = Convert.ToDecimal(row["prod_precio"])
                };

                productos.Add(cliente);
            }

            log.Info("Datos de productos enviados");
            return productos;

        }


        //obtener servicios
        [WebMethod]
        public List<Servicio> ObtenerServicios()
        {
            log.Debug("Se estan solicitando los servicios...");
            var dt = adaptarServicio.GetDataBy1(); //almacena los datos obteneidos del select

            var productos = new List<Servicio>();

            foreach (DataRow row in dt.Rows) //intera para obtener los datos
            {
                var cliente = new Servicio
                {
                    codigo = Convert.ToString(row["serv_codigo"]),
                    nombre = Convert.ToString(row["serv_nombre"]),
                    descripcion = Convert.ToString(row["serv_desc"]),
                    precio = Convert.ToDecimal(row["serv_precio"])
                };

                productos.Add(cliente);
            }

            log.Info("Datos de servicios enviados");
            return productos;

        }

        #endregion



        #region insertarDesdeCore
        //----------------------------------------
        //Insertar datos desde el core
        //----------------------------------------



        //Insertar Cajero
        [WebMethod]
        public void DelCoreCajero(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion)
        {


            log.Debug("Intentando insertar cajero...");
            try
            {
                //El parametro estado representara si se ha introducido el dato al Core, en este caso, estado=1 significa que si
                adaptarCajero.InsertarCajero(codigo, cedula, nombre, apellido, telefono, direccion, 1);
                log.Info("Se ha insertado un nuevo cajero con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el cajero...Exception:" + ex.Message);
            }



        }


        //Insertar Cliente
        [WebMethod]
        public void DelCoreCliente(string codigo, string cedula, string nombre, string apellido, string telefono, string direccion, decimal saldo)
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
        public void DelCoreServicio(string codigo, string nombre, string descripcion, decimal precio)
        {
            log.Debug("Intentando insertar Servicio...");
            try
            {

                adaptarServicio.InsertarServicio(codigo, nombre, descripcion, precio, 1);
                log.Info("Se ha insertado un nuevo Servicio con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el servicio...Exception:" + ex.Message);
            }


        }

        //Insertar factura
        [WebMethod]
        public void DelCoreFactura(string codigo, bool bit, DateTime fecha, decimal total, int metodoPago, string codigoCajero, string codigoCliente)
        {
            log.Debug("Intentando insertar Factura...");
            try
            {
                adaptarFactura.InsertarFactura(codigo, bit, fecha, total, metodoPago, codigoCajero, codigoCliente, 1);
                log.Info("Se ha insertado una nueva Factura con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura...Exception:" + ex.Message);
            }

        }

        //Insertar producto
        [WebMethod]
        public void DelCoreProducto(string codigo, string nombre, string descripcion, int stock, decimal precio)
        {
            log.Debug("Intentando insertar Producto...");
            try
            {
                adaptarProducto.InsertarProducto(codigo, nombre, descripcion, stock, precio, 1);
                log.Info("Se ha insertado un nuevo Producto con codigo:" + codigo);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar el producto...Exception:" + ex.Message);
            }

        }


        //Insertar factura_producto
        [WebMethod]
        public void DelCoreFacturaProducto(string codigoProducto, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Producto...");
            try
            {
                adaptarFCTProducto.InsertarFCTProducto(codigoProducto, codigoFactura, cantidad, precio, total, 1);
                log.Info("Se ha insertado un nuevo Factura_Producto con codigo producto:" + codigoProducto + " Y codigo factura:" + codigoFactura);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura_producto...Exception:" + ex.Message);
            }

        }

        //Insertar factura_servicio
        [WebMethod]
        public void DelCoreFacturaServicio(string codigoServicio, string codigoFactura, int cantidad, decimal precio, decimal total)
        {
            log.Debug("Intentando insertar datos a Factura_Servcio...");
            try
            {
                log.Info("Se ha insertado un nuevo Factura_Producto con codigo servicio:" + codigoServicio + " Y codigo factura:" + codigoFactura);
                adaptarFCTServicio.InsertarFCTServicio(codigoServicio, codigoFactura, cantidad, precio, total, 1);
            }
            catch (Exception ex)
            {
                log.Error("Error, no se ha podido ingresar la factura_servicio...Exception:" + ex.Message);
            }

        }

        #endregion



    }
}
