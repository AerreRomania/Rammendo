using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class RammendoImportRepository : BaseRepository, IRammendoImportRepository
    {
        public async Task<RammendoImport> GetRammendoAsync(string barcode) {
            var qry = @"
SELECT Commessa, Article, Color, Gradient, Size, Component, QtyPack, Barcode, Good, Bad, GoodGood, BadBad, Diff, Angajat, Reparto, TypeOfControl, Tavolo, CapiH, LastKey
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
            var qry = @"
UPDATE RammendoImport
SET GoodGood=@GoodGood, BadBad=@BadBad, Diff=@Diff, Angajat=@Angajat, Reparto=@Reparto, TypeOfControl=@TypeOfControl, Tavolo=@Tavolo
WHERE Barcode=@Barcode;";

            try {
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
    }
}
