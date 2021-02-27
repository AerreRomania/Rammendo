using Rammendo.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rammendo.Data.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Angajati>> GetAngajatis(string codAngajat);
    }
}
