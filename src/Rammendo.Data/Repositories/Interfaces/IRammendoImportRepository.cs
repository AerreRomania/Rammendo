using System.Threading.Tasks;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface IRammendoImportRepository
    {
        Task<RammendoImport> GetRammendoAsync(string barcode); 
        Task<int> UpdateRammendoAsync(RammendoImport commesse);
    }
}
