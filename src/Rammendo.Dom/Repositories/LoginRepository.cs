using Dapper;
using Rammendo.Dom.Entities;
using Rammendo.Dom.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Rammendo.Dom.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public async Task<IList<Angajati>> GetAngajatis(string codAngajat) {
            try {

                var qry = @" 
SELECT Id, CodAngajat, Angajat
FROM Angajati
WHERE CodAngajat=@CodAngajat AND IdSector=7";

                using (var conn = new SqlConnection(ConnectionString)) {
                    var result = await SqlMapper.QueryAsync<Angajati>(conn, qry, new { CodAngajat = codAngajat});
                    return result.ToList();
                }
            }
            catch {
                return null;
            }
        }
    }
}
