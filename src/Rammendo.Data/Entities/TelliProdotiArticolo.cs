using System;
using System.Collections.Generic;
using System.Text;

namespace Rammendo.Data.Entities
{
    public class TelliProdotiArticolo
    {
        public string Commessa { get; set; }
        public string Article { get; set; }
        public int BuoniDaRammendare { get; set; }
        public int Buoni { get; set; }
        public int DaRammendare { get; set; }
        public int Rammendati { get; set; }
        public int Scarti { get; set; }
        public int TeamRammendo { get; set; }
    }
}
