using AppRammendoMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppRammendoMobile.Services
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string url);

        Task<IEnumerable<T>> GetAllAsync<T>(string url);

        Task<bool> InsertAsync<T>(T settings, string url);

        Task<bool> UpdateAsync<T>(T settings, string url);

        Task<bool> DeleteAsync<T>(string url);
    }
}
