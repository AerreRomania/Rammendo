using Rammendo.Services;
using Rammendo.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rammendo.ViewModels
{
    public class BaseViewModel
    {
        public IApiService ApiService { get; set; }

        public BaseViewModel()
        {
            ApiService = new ApiService();
        }
    }
}
