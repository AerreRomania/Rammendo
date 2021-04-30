using Rammendo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammendo.ViewModels
{
    public class ProduzioneGanttViewModel : BaseViewModel
    {
        public async Task<IEnumerable<Workers>> GetWorkersAsync()
        {
            return await ApiService.GetAll<Workers>();
        }
    }
}
