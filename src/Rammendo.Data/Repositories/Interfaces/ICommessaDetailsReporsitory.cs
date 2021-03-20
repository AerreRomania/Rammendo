using System.Collections.Generic;
using System.Threading.Tasks;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ICommessaDetailsReporsitory
    {
        Task<IEnumerable<CommessaDetails>> GetCommessaDetailsAsync(string commessa);
    }
}
