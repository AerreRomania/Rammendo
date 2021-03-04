using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Repositories.Interfaces;
using Rammendo.Data.Entities;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class TelliProdotiRepository : BaseRepository, ITelliProdotiRepository
    {
        public async Task<IEnumerable<TelliProdoti>> GetAll(string article, string commessa) {
            var where = string.Empty;
            if (article != null) {
                where += @" AND Article=@Article";
            }
            if (commessa != null) {
                where += @" AND Commessa=@Commessa";
            }

            var qry = @" 
SELECT Article, Commessa, SUM(QtyPack) AS Prodoti, SUM(Bad) AS Rammendare                              
FROM RammendoImport";

            qry += @"
WHERE Article IS NOT NULL";
            qry += where;
            qry += @"
GROUP BY Article, Commessa
ORDER BY Article;";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdoti>(conn, qry, new { Article = article, Commessa = commessa });
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
