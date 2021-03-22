using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Entities;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RammendoLogController : Controller
    {
        private readonly IRammendoLogRepository _rammendoLogRepository;
        public RammendoLogController(IRammendoLogRepository rammendoLogRepository)
        {
            _rammendoLogRepository = rammendoLogRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertRammendoLog(Angajati angajati)
        {
            try
            {
                var rammendoImport = await _rammendoLogRepository.InsertAsync(angajati);
                return Ok();
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "An unexpected error occurred while fetching the rammendo on barcode {barcode}", barcode);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString()); ;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRammendoLog(Angajati angajati)
        {
            try
            {
                var rows = await _rammendoLogRepository.UpdateAsync(angajati);
                //Log.Debug("Successfully updated rammendo on barcode {barcode} and JobId", rammendoImport.Barcode, rammendoImport.LastKey);
                return Ok();
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "An unexpected error occurred while updating rammendo on barcode {barcode} and JobId", rammendoImport.Barcode, rammendoImport.LastKey);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}