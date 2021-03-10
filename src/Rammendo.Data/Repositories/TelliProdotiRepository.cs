using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Repositories.Interfaces;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class TelliProdotiRepository : BaseRepository, ITelliProdotiRepository
    {
        public async Task<IEnumerable<TelliProdoti>> GetAll(ReportFilter reportFilter) {
            var where = string.Empty;
            if (reportFilter.Article != null) {
                where += @"
AND Article=@Article";
            }
            if (reportFilter.Commessa != null) {
                where += @"
AND Commessa=@Commessa";
            }

            var qry = @" 
SELECT Article, Commessa, SUM(QtyPack) AS Prodoti, SUM(Bad) AS Rammendare, SUM(GoodGood) AS GoodGood, SUM(BadBad) AS BadBad, SUM(Diff) AS Diff                             
FROM RammendoImport";

            qry += @"
WHERE Article IS NOT NULL";
            qry += where;
            qry += @"
GROUP BY Article, Commessa
ORDER BY Article;";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdoti>(conn, qry, new { Article = reportFilter.Article, Commessa = reportFilter.Commessa });
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
