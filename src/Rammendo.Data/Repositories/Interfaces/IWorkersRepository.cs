using Rammendo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface IWorkersRepository
    {
        Task<IEnumerable<Workers>> GetWorkersAsync();
    }
}
