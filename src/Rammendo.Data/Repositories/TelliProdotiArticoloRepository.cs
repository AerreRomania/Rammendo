using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class TelliProdotiArticoloRepository : BaseRepository, ITelliProdotiArticoloRepository
    {
        public async Task<IEnumerable<TelliProdotiArticolo>> GetAll(ReportFilter reportFilter) {
            var where = string.Empty;
            if (reportFilter.Article != null) {
                where += @"
AND Article=@Article";
            }
            if (reportFilter.Commessa != null) {
                where += @"
AND Commessa=@Commessa";
            }
            if (reportFilter.Stagione != null) {
                where += @"
AND STAG.Stagiune=@Stagione";
            }
            if (reportFilter.Finezze != null) {
                where += @"
AND FIN.Codice=@Finezze";
            }

            var qry = @" 
SELECT RAM.Commessa, STAG.Stagiune, RAM.Article, FIN.Codice, 
(SUM(Good) + SUM(Bad)) AS BuoniDaRammendare, SUM(Good) AS Buoni, SUM(Bad) AS DaRammendare, SUM(GoodGood) AS Rammendati, SUM(BadBad) AS Scarti, SUM(TeamRammendo) AS TeamRammendo                              
FROM RammendoImport RAM
LEFT JOIN Stagiuni STAG ON RAM.IdStagione = STAG.Id
LEFT JOIN Fineza FIN ON RAM.IdFinezze = FIN.Id";

            qry += @"
WHERE RAM.Article IS NOT NULL AND RAM.CreatedDate BETWEEN @StartDate AND @EndDate";
            
            qry += where;

            qry += @"
GROUP BY RAM.Commessa, STAG.Stagiune, RAM.Article, FIN.Codice;";

            try {
                var dp = new DynamicParameters(reportFilter);
                
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdotiArticolo>(conn, qry, dp);
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
