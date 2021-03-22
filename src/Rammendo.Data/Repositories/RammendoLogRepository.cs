using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class RammendoLogRepository : BaseRepository, IRammendoLogRepository
    {
        public async Task<bool> InsertAsync(Angajati angajati) {
            var insertQuery = @"
INSERT INTO RammendoLog
(StartTime, EndTime, CodAngajat, Action) VALUES (GETDATE(), NULL, @CodAngajat, @Action)
";
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodAngajat", angajati.CodAngajat);
            dynamicParameters.Add("@Action", angajati.Action);

            using (var connection = new SqlConnection(ConnectionString)) {
                var row = await connection.ExecuteAsync(insertQuery, dynamicParameters);
                return row > 0;
            }
        }

        public async Task<bool> UpdateAsync(Angajati angajati) {
            var updateQuery = @"
UPDATE RammendoLog
SET EndTime=GETDATE()
WHERE CONVERT(NVARCHAR, StartTime, 110)=CONVERT(NVARCHAR, GETDATE(), 110) AND CodAngajat=@CodAngajat AND Action=@Action AND EndTime IS NULL
";

            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodAngajat", angajati.CodAngajat);
            dynamicParameters.Add("@Action", angajati.Action);

            using (var connection = new SqlConnection(ConnectionString)) {
                var row = await connection.ExecuteAsync(updateQuery, dynamicParameters);
                return row > 0;
            }
        }
    }
}
