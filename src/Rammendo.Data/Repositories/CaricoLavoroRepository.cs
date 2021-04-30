using Dapper;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using Rammendo.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories
{
    public class CaricoLavoroRepository : BaseRepository, ICaricoLavoroRepository
    {
        public async Task<IEnumerable<CaricoLavoro>> GetAllAsync(ReportFilter reportFilter)
        {
            var where = string.Empty;
            if (reportFilter.Article != null)
            {
                where += @"
AND Article=@Article";
            }
            if (reportFilter.Commessa != null)
            {
                where += @"
AND Commessa=@Commessa";
            }
            if (reportFilter.Finezze != null)
            {
                where += @"
AND FIN.Codice=@Finezze";
            }

            var qry = @"
SELECT RAM.Commessa, 
       RAM.Article, 
       FIN.Codice AS Finezza, 
       SUM(RAM.QtyPack) AS TotalQty,
       SUM(RAM.Good) AS Good, 
       SUM(RAM.Bad) AS Bad,
       SUM(RAM.GoodGood) AS GoodGood, 
       SUM(RAM.BadBad) AS BadBad,
       SUM(RAM.Diff) AS Diff,
       MAX(RAM.CreatedDate) AS DataLettura
FROM RammendoImport RAM
LEFT JOIN Fineza FIN ON RAM.IdFinezze = FIN.Id";

            qry += @"
WHERE RAM.Commessa IS NOT NULL AND RAM.CreatedDate BETWEEN @StartDate AND @EndDate
";
            qry += where;

            qry += @"
GROUP BY RAM.Commessa,
         RAM.Article, 
         FIN.Codice;";

            try
            {
                var dp = new DynamicParameters(reportFilter);
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var result = await SqlMapper.QueryAsync<CaricoLavoro>(conn, qry, dp);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
