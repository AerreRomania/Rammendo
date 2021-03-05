using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppRammendoMobile.Models
{
   public class Angajati
    {
        [Key]
        public int Id { get; set; }
        public string CodAngajat { get; set; }
        public string Angajat { get; set; }
    }
}
