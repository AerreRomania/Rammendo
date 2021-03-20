using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rammendo.Data.Entities
{
    public class RammendoStart {
        [Key]
        public int Id { get; set; }
        public DateTime StartTime {get; set; }
        public DateTime EndTime { get; set; }
        public string Angajat { get; set; }
        public string Type  { get; set; }
        public DateTime CurrentTime { get; set; }
    }
}
