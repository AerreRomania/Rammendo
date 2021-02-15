using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Rammendo.Data.Repositories.Interfaces;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories
{
    public class TelliProdotiRepository : BaseRepository, ITelliProdotiRepository
    {
        public async Task<IEnumerable<TelliProdoti>> GetAll() {
            try {
                var qry = @" SELECT Article, Commessa, SUM(QtyPack) AS Prodoti, SUM(Bad) AS Rammendare 
                             FROM RammendoImport GROUP BY Article, Commessa
                             ORDER BY Article, Commessa;";

                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<TelliProdoti>(conn, qry);
                    return result;
                }
            }
            catch {
                return null;
            }
        }
    }
}
