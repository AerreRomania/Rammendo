using Dapper;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories
{
    public class WorkersRepository : BaseRepository, IWorkersRepository
    {
        public async Task<IEnumerable<Workers>> GetWorkersAsync()
        {
            var qry = @"
SELECT Angajat AS Name, 
       Linie AS Line
FROM Angajati 
WHERE Active=1
AND IdSector=7
AND Mansione='RAMMENDO'
ORDER BY Linie;";

            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    var result = await SqlMapper.QueryAsync<Workers>(conn, qry);
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
