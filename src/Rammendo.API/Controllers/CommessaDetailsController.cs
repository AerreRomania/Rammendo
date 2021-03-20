using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommessaDetailsController : Controller
    {
        readonly ICommessaDetailsReporsitory _commessaDetailsReporsitory;

        public CommessaDetailsController(ICommessaDetailsReporsitory commessaDetailsReporsitory) {
            _commessaDetailsReporsitory = commessaDetailsReporsitory;
        }

        [HttpPost]
        public async Task<IEnumerable<CommessaDetails>> GetCommessaDetailsAsync(string commessa) {
            try {
                var commessaDetails = await _commessaDetailsReporsitory.GetCommessaDetailsAsync(commessa);
                Log.Debug("Successfully loaded commessa for {commessa}", commessa);

                return commessaDetails;
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while fetching the commessa details on {commessa}", commessa);
                return null;
            }
        }
    }
}