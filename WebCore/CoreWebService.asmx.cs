using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;
using WebCore.Modelos;
using WebCore.WebCoreDataSetTableAdapters;
using static WebCore.WebCoreDataSet;

namespace WebCore
{
    /// <summary>
    /// Descripción breve de CoreWebService
    /// </summary>
    [WebService(Namespace = "http://google.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class CoreWebService : System.Web.Services.WebService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        [WebMethod]
        public void WCLog()
        {
            log.Info("Prueba del log"); // El log va antes del return
            //log.Debug("");
            //log.Error("");
        }


        [WebMethod]
        public int InsertCajero(WCCajero _WCCajero)
        {
            CAJEROTableAdapter myCAJEROTableAdapter = new CAJEROTableAdapter();

            int respQwery = myCAJEROTableAdapter.ppInsertCAJERO(_WCCajero.cjr_codigo, _WCCajero.cjr_cedula, _WCCajero.cjr_nombre, _WCCajero.cjr_apellido, _WCCajero.cjr_telefono, _WCCajero.cjr_direccion);

            return respQwery;
        }

        [WebMethod]
        public int InsertCliente(WCCliente _WCCliente)
        {
            CLIENTETableAdapter myCAJEROTableAdapter = new CLIENTETableAdapter();

            int respQwery = myCAJEROTableAdapter.ppInsertCliente(_WCCliente.clt_codigo, _WCCliente.clt_cedula, _WCCliente.clt_nombre, _WCCliente.clt_apellido, _WCCliente.clt_telefono, _WCCliente.clt_direccion, _WCCliente.clt_saldo);

            return respQwery;
        }

        [WebMethod]
        public int InsertProducto(WCProducto _WCProducto)
        {
            PRODUCTOTableAdapter myCAJEROTableAdapter = new PRODUCTOTableAdapter();

            int respQwery = myCAJEROTableAdapter.ppInsertProducto(
                _WCProducto.codigo, 
                _WCProducto.nombre, 
                _WCProducto.desc, 
                _WCProducto.stock, 
                _WCProducto.precio);

            return respQwery;
        }

        [WebMethod]
        public int InsertServicio(WCServicio _WCProducto)
        {
            SERVICIOTableAdapter mySERVICIOTableAdapter = new SERVICIOTableAdapter();

            int respQwery = mySERVICIOTableAdapter.ppInsertServicio(
                _WCProducto.codigo,
                _WCProducto.nombre,
                _WCProducto.desc,
                _WCProducto.precio);

            return respQwery;
        }

        #region :::::::::::::::: Registrar una factura

        [WebMethod]
        public int InsertFactura(WCFactura _WCFactura)
        {
            FACTURATableAdapter myFACTURAOTableAdapter = new FACTURATableAdapter();

            int respQwery = myFACTURAOTableAdapter.ppInsertFactura(
                _WCFactura.codigo,
                _WCFactura.cotizacion,
                _WCFactura.fecha,
                _WCFactura.total,
                _WCFactura.metodoPago,
                _WCFactura.cjrCodigo,
                _WCFactura.cltCodigo);

            return respQwery;
        }

        [WebMethod]
        public int InsertFct_Prod(WCFct_Prod _WCFct_Prod)
        {
            FCT_PRODTableAdapter myFCT_PRODTableAdapter = new FCT_PRODTableAdapter();

            int respQwery = myFCT_PRODTableAdapter.ppInsertFct_Prod(
                _WCFct_Prod.prodCodigo,
                _WCFct_Prod.fctCodigo,
                _WCFct_Prod.cantidad,
                _WCFct_Prod.precioUnidad,
                _WCFct_Prod.total);

            return respQwery;
        }

        [WebMethod]
        public int InsertFct_Serv(WCFct_Serv _WCFct_Serv)
        {
            FCT_SERVTableAdapter myFCT_SERVTableAdapter = new FCT_SERVTableAdapter();

            int respQwery = myFCT_SERVTableAdapter.ppInsertFct_Serv(
                _WCFct_Serv.servCodigo,
                _WCFct_Serv.fctCodigo,
                _WCFct_Serv.cantidad,
                _WCFct_Serv.precioUnidad,
                _WCFct_Serv.total);

            return respQwery;
        }

        #endregion

        #region :::::::::::::::: Producto 

        [WebMethod]
        public PRODUCTODataTable SelectProductos()
        {
            PRODUCTOTableAdapter myPRODUCTOTableAdapter = new PRODUCTOTableAdapter();

            PRODUCTODataTable myPRODUCTODataTable = myPRODUCTOTableAdapter.GetData();

            return myPRODUCTODataTable;
        }

        #endregion :::::::::::::::: Producto










        [WebMethod]
        public USUARIODataTable BuscarUsuario(string codigo_in, string clave_in)
        {

            USUARIOTableAdapter myUSUARIOTableAdapter = new USUARIOTableAdapter();

            USUARIODataTable myUSUARIODataTable = myUSUARIOTableAdapter.GetDataByCodigoYClave(codigo_in, clave_in);

            return myUSUARIODataTable;
        }

        [WebMethod]
        public USUARIODataTable SelectUsuarios()
        {

            USUARIOTableAdapter myUSUARIOTableAdapter = new USUARIOTableAdapter();

            USUARIODataTable myUSUARIODataTable = myUSUARIOTableAdapter.GetData();

            return myUSUARIODataTable;
        }
    }
}


