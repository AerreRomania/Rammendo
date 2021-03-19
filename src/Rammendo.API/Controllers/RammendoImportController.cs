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
    public class RammendoImportController : Controller
    {
        readonly IRammendoImportRepository _rammendoImportRepository;

        public RammendoImportController(IRammendoImportRepository rammendoImportRepository) {
            _rammendoImportRepository = rammendoImportRepository;
        }

        [HttpPost]
        public async Task<RammendoImport> GetRammendoAsync(string barcode)
        {
            try {
                var rammendoImport = await _rammendoImportRepository.GetRammendoAsync(barcode);  
                Log.Debug("Successfully loaded rammendo on barcode {barcode}", barcode);

                return rammendoImport;
            }
            catch (Exception ex) {     
                Log.Error(ex, "An unexpected error occurred while fetching the rammendo on barcode {barcode}", barcode);
                return null;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateRammendoImport(RammendoImport rammendoImport) {
            try {
                var rows = await _rammendoImportRepository.UpdateRammendoAsync(rammendoImport);
                Log.Debug("Successfully updated rammendo on barcode {barcode} and JobId", rammendoImport.Barcode, rammendoImport.LastKey);
                return Ok();
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while updating rammendo on barcode {barcode} and JobId", rammendoImport.Barcode, rammendoImport.LastKey);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
            }
        }
    }
}