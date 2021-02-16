using System.Collections.Generic;
using System.Threading.Tasks;
using Rammendo.Dom.Entities;

namespace Rammendo.Dom.Repositories.Interfaces
{
    public interface ITelliProdotiRepository
    {
        Task<IEnumerable<TelliProdoti>> GetAll();
    }
}
