using System;

namespace Rammendo.Models.Filters
{
    public class ReportFilter
    {
        public string Commessa { get; set; }
        public string Article { get; set; }
        public string Stagione { get; set; }
        public string Finezze { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
