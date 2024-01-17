using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class WCCliente
    {
        public string clt_codigo { get; set; }
        public string clt_cedula { get; set; }
        public string clt_nombre { get; set; }
        public string clt_apellido { get; set; }
        public string clt_telefono { get; set; }
        public string clt_direccion { get; set; }
        public decimal clt_saldo {  get; set; }
    }
}
