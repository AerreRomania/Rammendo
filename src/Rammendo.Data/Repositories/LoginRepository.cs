using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public async Task<IEnumerable<Angajati>> GetAngajatis(string codAngajat) {
            var qry = @" 
SELECT CodAngajat, Angajat
FROM Angajati
WHERE CodAngajat=@CodAngajat AND IdSector=7;";
            //TODO check column [Active] does take an effect
            try {
                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<Angajati>(conn, qry, new { CodAngajat = codAngajat });
                    return result.ToList();
                }
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
