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
    public class CaricoLavoroController : Controller
    {
        readonly ICaricoLavoroRepository _caricoLavoroRepository;

        public CaricoLavoroController(ICaricoLavoroRepository caricoLavoroRepository)
        {
            _caricoLavoroRepository = caricoLavoroRepository;
        }

        [HttpPost]
        public async Task<IEnumerable<CaricoLavoro>> GetAllAsync([FromBody] ReportFilter reportFilter)
        {
            try
            {
                var caricoLavoro = await _caricoLavoroRepository.GetAllAsync(reportFilter);
                Log.Debug("Successfully loaded caricoLavoro " +
                    "on article: {article} and commessa {commessa}", reportFilter.Article, reportFilter.Commessa);

                return caricoLavoro;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error occurred while fetching the caricoLavoro " +
                    "on article: {article} and commessa {commessa}", reportFilter.Article, reportFilter.Commessa);
                return null;
            }
        }
    }
}