using System.Collections.Generic;
using System.Threading.Tasks;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ITelliProdotiRepository
    {
        Task<IEnumerable<TelliProdoti>> GetAll(ReportFilter reportFilter);
    }
}
