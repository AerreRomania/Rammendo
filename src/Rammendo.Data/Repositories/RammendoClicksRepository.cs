using Dapper;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories
{
    public class RammendoClicksRepository : BaseRepository, IRammendoClicksRepository
    {
        public Task<IEnumerable<RammendoHour>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertAsync(RammendoClicks rammendoClicks) {
            var insertQuery = @"
INSERT INTO RammendoClicks (ClickEvent,Angajat,Quantity,IdJob,TypeOfWork)
VALUES (@ClickEvent,@Angajat,@Quantity,@IdJob,@TypeOfWork)
";
            using (var connection = new SqlConnection(ConnectionString)) {
                var row = await connection.ExecuteAsync(insertQuery, rammendoClicks);
                return row > 0;
            }
        }
    }
}
