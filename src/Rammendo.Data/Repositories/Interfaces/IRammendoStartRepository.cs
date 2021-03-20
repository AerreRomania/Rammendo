using Rammendo.Data.Entities;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface IRammendoStartRepository
    {
        Task<bool> InsertAsync(RammendoStart rammendoStart);
        Task<bool> UpdateAsync(RammendoStart rammendoStart);
    }
}
