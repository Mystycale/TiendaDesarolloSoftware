using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class WCFct_Serv
    {
        public string fctCodigo { get; set; }
        public string servCodigo { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnidad { get; set; }
        public decimal total { get; set; }
    }
}