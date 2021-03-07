using System.Collections.Generic;
using System.Threading.Tasks;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface IRammendoClicksRepository
    {
        Task<IEnumerable<RammendoHour>> GetAllAsync();
        Task<bool> InsertAsync(RammendoClicks rammendoClicks);
    }
}
