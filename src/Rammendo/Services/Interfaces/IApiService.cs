using Rammendo.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rammendo.Services.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<T>> GetAll<T>(string query);

        Task<IEnumerable<T>> GetAllByFilter<T>(ReportFilter reportFilter);
    }
}
