﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCore.Modelos
{
    public class WCFct_Prod
    {
        public string fctCodigo { get; set; }
        public string prodCodigo { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnidad { get; set; }
        public decimal total { get; set; }
    }
}