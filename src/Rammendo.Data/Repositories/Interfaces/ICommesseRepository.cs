using System.Threading.Tasks;
using Rammendo.Data.Entities;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ICommesseRepository
    {
        Task<Commesse> GetAsync(string barcode); 
        Task<int> PutAsync(Commesse commesse);
    }
}
