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

            //WCRespuesta _WCRespuesta = new WCRespuesta();

            //_WCRespuesta.Mensaje = myCAJEROTableAdapter.ppInsertCAJERO(_WCCajero.cjr_codigo, _WCCajero.cjr_cedula, _WCCajero.cjr_nombre, _WCCajero.cjr_apellido, _WCCajero.cjr_telefono, _WCCajero.cjr_direccion);
            int respQwery = myCAJEROTableAdapter.ppInsertCAJERO(_WCCajero.cjr_codigo, _WCCajero.cjr_cedula, _WCCajero.cjr_nombre, _WCCajero.cjr_apellido, _WCCajero.cjr_telefono, _WCCajero.cjr_direccion);


            //MessageBox.Show(respQwery.ToString(), "Mensaje del WebCore", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //_WCRespuesta.Codigo = 100;

            return respQwery;
        }

        [WebMethod]
        public USUARIODataTable BuscarUsuario(string codigo_in, string clave_in)
        {

            USUARIOTableAdapter myUSUARIOTableAdapter = new USUARIOTableAdapter();

            USUARIODataTable myUSUARIODataTable = myUSUARIOTableAdapter.GetDataByCodigoYClave(codigo_in, clave_in);

            return myUSUARIODataTable;
        }
    }
}


