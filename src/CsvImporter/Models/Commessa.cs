namespace CsvImporter.Models
{
    public class Commessa
    {
        public int CommessaId { get; set; }
        public string NrCommanda { get; set; }
        public int ArticleId { get; set; }
        public string Article { get; set; }
        public double CapiH { get; set; }
        public int IdStagione { get; set; }
        public int IdFinezze { get; set; }
    }
}
