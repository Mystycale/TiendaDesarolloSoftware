using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class WCFactura
    {
        public string codigo { get; set; }
        public bool cotizacion { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public int metodoPago { get; set; }
        public string cjrCodigo { get; set; }
        public string cltCodigo { get; set; }
    }
}