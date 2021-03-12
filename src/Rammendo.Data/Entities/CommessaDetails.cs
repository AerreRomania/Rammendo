using System;
using System.Collections.Generic;
using System.Text;

namespace Rammendo.Data.Entities
{
    public class CommessaDetails
    {
        public string Color { get; set; }
        public string Size { get; set; }
        public string Component { get; set; }
        public int QtyPack { get; set; }
        public string Barcode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Good { get; set; }
        public int Bad { get; set; }
        public int BadBad { get; set; }
        public int GoodGood { get; set; }
    }
}
