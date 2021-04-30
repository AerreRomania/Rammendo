using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ICaricoLavoroRepository
    {
        Task<IEnumerable<CaricoLavoro>> GetAllAsync(ReportFilter reportFilter);
    }
}
