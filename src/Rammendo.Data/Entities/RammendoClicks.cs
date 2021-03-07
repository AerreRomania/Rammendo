using System;

namespace Rammendo.Data.Entities
{
    public class RammendoClicks
    {
        public DateTime ClickEvent { get; set; }
        public string Angajat { get; set; }
        public int Quantity { get; set; }
        public int IdJob { get; set; }
    }
}
