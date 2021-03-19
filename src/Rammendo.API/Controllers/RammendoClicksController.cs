using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RammendoClicksController : Controller
    {
        readonly IRammendoClicksRepository _rammendoClicksRepository;

        public RammendoClicksController(IRammendoClicksRepository rammendoClicksRepository) {
            _rammendoClicksRepository = rammendoClicksRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetRammendoAsync(RammendoClicks rammendoClicks) {
            try {
                var rmClicks = await _rammendoClicksRepository.InsertAsync(rammendoClicks);
                Log.Debug("Successfully inserted rammendo click on barcode {barcode}", rammendoClicks.IdJob);

                return Ok();
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while inserting the rammendo click on barcode {barcode}", rammendoClicks.IdJob);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}