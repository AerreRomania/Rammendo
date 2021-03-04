using AppRammendoMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppRammendoMobile.Services
{
    public interface ILoginClient
    {
        Task<Angajati> LoginUserAsync(string url);
    }
}
