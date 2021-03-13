using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ITelliProdotiPersoneRepository
    {
        Task<IEnumerable<TelliProdotiPersone>> GetAll(ReportFilter reportFilter);
    }
}
