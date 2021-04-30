using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;
using System.Globalization;

namespace Rammendo.Data.Repositories
{
    public class RammendoImportRepository : BaseRepository, IRammendoImportRepository
    {
        public async Task<RammendoImport> GetRammendoAsync(string barcode) {
            var qry = @"
SELECT Commessa, Article, Color, Gradient, Size, Component, QtyPack, Barcode, Good, Bad, 
GoodGood, BadBad, Diff, Angajat, Reparto, TypeOfControl, Tavolo, CapiH, LastKey
FROM RammendoImport
WHERE Barcode=@Barcode;";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryFirstOrDefaultAsync<RammendoImport>(conn, qry, new { Barcode = barcode });
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<int> UpdateRammendoAsync(RammendoImport rammendoImport) {
            if (rammendoImport.StartJob != null) rammendoImport.StartJob = DateTime.Now;
            if (rammendoImport.EndJob != null) rammendoImport.EndJob = DateTime.Now;

            var qry = @"
UPDATE RammendoImport
SET GoodGood=@GoodGood, BadBad=@BadBad, Diff=@Diff, Angajat=@Angajat, Reparto=@Reparto, TypeOfControl=@TypeOfControl, Tavolo=@Tavolo,
StartJob=CASE WHEN StartJob IS NULL THEN @StartJob ELSE StartJob END, 
EndJob=CASE WHEN EndJob IS NULL THEN @EndJob ELSE EndJob END
WHERE Barcode=@Barcode;";

            try {
                await InsertProductionAsync(rammendoImport.Angajat, rammendoImport.Barcode);

                var dynamicParameters = new DynamicParameters(rammendoImport);

                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await conn.ExecuteAsync(qry, dynamicParameters);
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<bool> InsertProductionAsync(string operat, string barcode)
        {
            var insertQuery = @"
INSERT INTO RammendoProduction
(Operator, ProductionDate, Barcode, Qty) VALUES (@Operator, GETDATE(), @Barcode, 1);
";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Operator", operat);
            dynamicParameters.Add("@Barcode", barcode);

            using (var connection = new SqlConnection(ConnectionString))
            {
                var row = await connection.ExecuteAsync(insertQuery, dynamicParameters);
                return row > 0;
            }
        }
    }
}
