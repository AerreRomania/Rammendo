using System.Data.SqlClient;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Dapper;

namespace Rammendo.Data.Repositories
{
    public class RammendoStartRepository : BaseRepository, IRammendoStartRepository
    {
        public async Task<bool> InsertAsync(RammendoStart rammendoStart) {
            var insertQuery = @"
INSERT INTO RammendoStart 
(StartTime, EndTime, Angajat, Type)
VALUES (@StartTime, @EndTime, @Angajat, @Type)
";
            using (var connection = new SqlConnection(ConnectionString)) {
                var row = await connection.ExecuteAsync(insertQuery, rammendoStart);
                return row > 0;
            }
        }

        public async Task<bool> UpdateAsync(RammendoStart rammendoStart) {
            var updateQuery = @"
UPDATE RammendoStart SET
EndTime=@EndTime
WHERE StartTime=@StartTime AND Type=@Type AND Angajat=@Angajat
";
            using (var connection = new SqlConnection(ConnectionString)) {
                var row = await connection.ExecuteAsync(updateQuery, rammendoStart);
                return row > 0;
            }
        }
    }
}
