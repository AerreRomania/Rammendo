using System;
using System.Collections.Generic;
using System.Text;

namespace Rammendo.Data.Entities
{
    public class Commesse
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
        public int ComenziId { get; set; }
        public int ComeziArticolId { get; set; }
    }
}
