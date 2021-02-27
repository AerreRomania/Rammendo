using Rammendo.Dom.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rammendo.Dom.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<IList<Angajati>> GetAngajatis(string codAngajat);
    }
}
