using System;
using System.Threading.Tasks;

namespace AppRammendoMobile.Services
{
    public interface ICameraScanner
    {
        Task<string> ScanAsync();
    }
}
