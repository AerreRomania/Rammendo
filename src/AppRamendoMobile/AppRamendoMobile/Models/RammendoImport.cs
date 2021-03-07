using System;
using System.Collections.Generic;
using System.Text;

namespace AppRammendoMobile.Models
{
    public class RammendoImport
    {
        public string Commessa { get; set; }
        public string Article { get; set; }
        public string Color { get; set; }
        public string Gradient { get; set; }
        public string Size { get; set; }
        public string Component { get; set; }
        public int QtyPack { get; set; }
        public string Barcode { get; set; }
        public int Good { get; set; }
        public int Bad { get; set; }
        public int GoodGood { get; set; }
        public int BadBad { get; set; }
        public int Diff { get; set; }
        public string Angajat { get; set; }
        public string Reparto { get; set; }
        public string TypeOfControl { get; set; }
        public string Tavolo { get; set; }
        public double CapiH { get; set; }
        public int LastKey { get; set; }
    }
}
