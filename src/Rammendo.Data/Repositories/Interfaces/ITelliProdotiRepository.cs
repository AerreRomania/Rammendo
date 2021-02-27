using System.Collections.Generic;
using System.Threading.Tasks;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ITelliProdotiRepository
    {
        Task<IEnumerable<TelliProdoti>> GetAll(string article, string commessa);
    }
}
