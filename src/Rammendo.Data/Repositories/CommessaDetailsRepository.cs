using Dapper;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories
{
    public class CommessaDetailsRepository : BaseRepository, ICommessaDetailsReporsitory
    {
        public async Task<IEnumerable<CommessaDetails>> GetCommessaDetailsAsync(string commessa) {
            var qry = @"
SELECT Color, Size, Component, QtyPack, Barcode, CreatedDate, Good, Bad, BadBad, GoodGood 
FROM RammendoImport
WHERE Commessa=@Commessa;";

            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<CommessaDetails>(conn, qry, new { Commessa = commessa });
                    return result;
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
