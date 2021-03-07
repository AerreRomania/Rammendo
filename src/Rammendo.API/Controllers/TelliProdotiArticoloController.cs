using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Entities;
using Rammendo.Data.Entities.Filters;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelliProdotiArticoloController : Controller
    {
        readonly ITelliProdotiArticoloRepository _telliProdotiArticoloRepository;

        public TelliProdotiArticoloController(ITelliProdotiArticoloRepository telliProdotiArticoloRepository) {
            _telliProdotiArticoloRepository = telliProdotiArticoloRepository;
        }

        [HttpPost]
        public async Task<IEnumerable<TelliProdotiArticolo>> GetAllAsync([FromBody] ReportFilter reportFilter) {
            try {
                var telliProdotiArticolo = await _telliProdotiArticoloRepository.GetAll(reportFilter);
                Log.Debug("Successfully loaded telliProdotiArticolo " +
                    "on article: {article} and commessa {commessa}", reportFilter.Article, reportFilter.Commessa);

                return telliProdotiArticolo;
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while fetching the telliProdotiArticolo " +
                    "on article: {article} and commessa {commessa}", reportFilter.Article, reportFilter.Commessa);
                return null;
            }
        }
    }
}