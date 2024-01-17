using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class WCProducto
    {
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string desc { get; set; }
        public int stock { get; set; }
        public decimal precio { get; set; }
    }
}