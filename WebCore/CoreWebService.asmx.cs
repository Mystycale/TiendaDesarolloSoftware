using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebCore.WebCoreDataSetTableAdapters;

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
        public string HelloWorld()
        {
            log.Info("Prueba del log"); // El log va antes del return
            //log.Debug("");
            //log.Error("");
            return "Hola a todos";
        }


        [WebMethod]
        public void InsertCajero(string cjr_codigo, string cjr_cedula, string cjr_nombre, string cjr_apellido, string cjr_telefono, string cjr_direccion)
        {
            CAJEROTableAdapter myCAJEROTableAdapter = new CAJEROTableAdapter();
            myCAJEROTableAdapter.ppInsertCAJERO(cjr_codigo, cjr_cedula, cjr_nombre, cjr_apellido, cjr_telefono, cjr_direccion);
        }
    }
}


