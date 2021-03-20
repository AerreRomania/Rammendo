using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelliProdotiPersoneController : Controller
    {
        readonly ITelliProdotiPersoneRepository _telliProdotiPersoneRepository;

        public TelliProdotiPersoneController(ITelliProdotiPersoneRepository telliProdotiPersoneRepository) {
            _telliProdotiPersoneRepository = telliProdotiPersoneRepository;
        }

        [HttpPost]
        public async Task<IEnumerable<TelliProdotiPersone>> GetAllAsync([FromBody] ReportFilter reportFilter) {
            try {
                var telliProdotiArticolo = await _telliProdotiPersoneRepository.GetAll(reportFilter);
                Log.Debug("Successfully loaded telliProdotipersone");

                return telliProdotiArticolo;
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while fetching the telliProdotipersone");
                return null;
            }
        }
    }
}