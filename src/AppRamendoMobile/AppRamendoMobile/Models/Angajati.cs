using System;
using System.ComponentModel.DataAnnotations;

namespace AppRammendoMobile.Models
{
   public class Angajati
    {
        [Key]
        public int Id { get; set; }
        public string CodAngajat { get; set; }
        public string Angajat { get; set; }
        public string Action { get; set; }
    }
}
