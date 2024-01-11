using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [WebMethod]
        public string HelloWorld()
        {
            log.Info("Prueba"); //Los log van siempre antes del return

            return "Hola a todos";
            
        }
    }
}
