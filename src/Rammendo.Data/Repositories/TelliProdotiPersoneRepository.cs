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
    public class TelliProdotiPersoneRepository : BaseRepository, ITelliProdotiPersoneRepository
    {
        public async Task<IEnumerable<TelliProdotiPersone>> GetAll(ReportFilter reportFilter) {
            var qry = @" 
SELECT CONVERT(NVARCHAR, StartJob, 110) AS CreatedDate, Angajat, TypeOfControl, SUM(GoodGood) as Rammendati,
SUM(DATEDIFF(second, StartJob, EndJob)) AS Duration , SUM(CapiH) / Count(1) AS PezziH
FROM RammendoImport
WHERE Angajat IS NOT NULL AND TypeOfControl IS NOT NULL AND StartJob BETWEEN @StartDate AND @EndDate
GROUP BY CONVERT(NVARCHAR, StartJob, 110), Angajat, TypeOfControl
ORDER BY CONVERT(NVARCHAR, StartJob, 110), Angajat, TypeOfControl;";

            try {
                var dp = new DynamicParameters();
                dp.Add("@StartDate", reportFilter.StartDate);
                dp.Add("@EndDate", reportFilter.EndDate);

                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdotiPersone>(conn, qry, dp);
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
