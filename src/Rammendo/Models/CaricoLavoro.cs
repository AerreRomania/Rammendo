using System;

namespace Rammendo.Models
{
    public class CaricoLavoro
    {
        public string Commessa { get; set; }
        public string Article { get; set; }
        public string Finezza { get; set; }
        public int TotalQty { get; set; }
        public int Good { get; set; }
        public int Bad { get; set; }
        public int GoodGood { get; set; }
        public int BadBad { get; set; }
        public int Diff { get; set; }
        public DateTime DataLettura { get; set; }
    }
}
