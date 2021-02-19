using CsvImporter.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CsvImporter
{
    public static class CsvInfo
    {
        public const string CSV_PATH = "D:\\Rammendo Import";
        public const string CONNECTION_STRING = "data source=192.168.96.37;initial catalog=ONLYOU; User ID=nicu; password=onlyouolimpias;";

        private static readonly Log _log = new Log();

        public static int GetMaxKeyBasedOnImport(string fileName) {

            var qry = @"
SELECT MAX(LastKey) 
FROM RammendoImport 
WHERE FileKey=@fileName;";

            try {
                var maxKey = 0;

                using (var conn = new SqlConnection(CONNECTION_STRING)) {
                    var cmd = new SqlCommand(qry, conn);
                    cmd.Parameters.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            int.TryParse(dr[0].ToString(), out maxKey);
                        }
                    }
                    conn.Close();
                    dr.Close();
                }
                return maxKey;
            }
            catch (System.Exception ex) {
                _log.WriteLog($"[GETMAXKEY] Error: {ex.Message}");
                return 0;
            }
        }

        public static IEnumerable<Commessa> GetCommessa() {
            var qry = @"
SELECT COM.Id, 
       COM.NrComanda, 
       COM.IdArticol, 
       ART.Articol
FROM Comenzi COM
INNER JOIN Articole ART ON COM.IdArticol = ART.Id
WHERE COM.IdSector=7;";

            var lst = new List<Commessa>();

            try {
                using (var conn = new SqlConnection(CONNECTION_STRING)) {
                    var cmd = new SqlCommand(qry, conn);
                    conn.Open();
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows) {
                        while (dr.Read()) {
                            int.TryParse(dr[0].ToString(), out var commessaId);
                            var commessa = dr[1].ToString();
                            int.TryParse(dr[2].ToString(), out var articleId);
                            var article = dr[3].ToString();
                            var commessaItem = new Commessa {
                                CommessaId = commessaId,
                                NrCommanda = commessa,
                                ArticleId = articleId,
                                Article = article
                            };
                            lst.Add(commessaItem);
                        }
                    }
                    conn.Close();
                    dr.Close();
                }
                return lst;
            }
            catch (System.Exception ex) {
                _log.WriteLog($"[GETMAXKEY] Error: {ex.Message}");
                return lst.DefaultIfEmpty<Commessa>();
            }
        }
    }
}
