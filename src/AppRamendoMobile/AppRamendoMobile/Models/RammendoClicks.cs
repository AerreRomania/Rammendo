using System;

namespace AppRammendoMobile.Models
{
    public class RammendoClicks
    {
        public DateTime ClickEvent { get; set; }
        public string Angajat { get; set; }
        public int Quantity { get; set; }
        public string IdJob { get; set; }
        public string TypeOfWork { get; set; }
    }
}
