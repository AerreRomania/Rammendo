using System.ComponentModel.DataAnnotations;

namespace Rammendo.Data.Entities
{
    public class Angajati
    {
        [Key]
        public int Id { get; set; }
        public string CodAngajat { get; set; }
        public string Angajat { get; set; }
    }
}
