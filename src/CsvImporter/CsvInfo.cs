using System.Data;
using System.Data.SqlClient;

namespace CsvImporter
{
    public static class CsvInfo
    {
        public const string CSV_PATH = "D:\\Rammendo Import";
        public const string CONNECTION_STRING = "data source=192.168.96.37;initial catalog=ONLYOU; User ID=nicu; password=onlyouolimpias;";
        
        public static int GetMaxKey(string fileName) {

            var qry = @"
SELECT MAX(LastKey) 
FROM RammendoImport
WHERE FileKey=@fileName;";
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
    }
}
