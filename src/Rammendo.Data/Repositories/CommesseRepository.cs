using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class CommesseRepository : BaseRepository, ICommesseRepository
    {
        public async Task<Commesse> GetAsync(string barcode) {
            var qry = @"
SELECT Commessa, Article, Color, Gradient, Size, Component, QtyPack, Barcode, Good, Bad, ComenziId, ComeziArticolId
FROM RammendoImport
WHERE Barcode=@Barcode;
";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryFirstOrDefaultAsync<Commesse>(conn, qry, new { Barcode = barcode });
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }

        public async Task<int> PutAsync(Commesse commesse) {
            var qry = @"
UPDATE RammendoImport
SET GoodGood=@GoodGood, BadBad=@BadBad, Dif=@Dif
WHERE Barcode=@Barcode;
";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.ExecuteAsync(conn, qry, new { Barcode = commesse.Barcode});
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
