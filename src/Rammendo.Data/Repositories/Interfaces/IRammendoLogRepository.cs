using Rammendo.Data.Entities;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface IRammendoLogRepository
    {
        Task<bool> InsertAsync(Angajati angajati);
        Task<bool> UpdateAsync(Angajati angajati);
    }
}
