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
WHERE Article IS NOT NULL AND CreatedDate BETWEEN @StartDate AND @EndDate";
            qry += where;
            qry += @"
GROUP BY Article, Commessa
ORDER BY Article;";

            try {
                var dp = new DynamicParameters();
                dp.Add("@Article", reportFilter.Article);
                dp.Add("@Commessa", reportFilter.Commessa);
                dp.Add("@StartDate", reportFilter.StartDate);
                dp.Add("@EndDate", reportFilter.EndDate);
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdoti>(conn, qry, dp);
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
