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
    public class TelliProdotiController : Controller
    {
        readonly ITelliProdotiRepository _telliProdotiRepository;

        public TelliProdotiController(ITelliProdotiRepository telliProdotiRepository) {
            _telliProdotiRepository = telliProdotiRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TelliProdoti>> GetAllAsync(string article, string commessa) {
            try {
                var telliProdotis = await _telliProdotiRepository.GetAll(article, commessa);
                Log.Debug("Successfully loaded telliProdoti " +
                    "on article: {article} and commessa {commessa}", article, commessa);

                return telliProdotis;
            }
            catch (Exception ex) {
                Log.Error(ex, "An unexpected error occurred while fetching the telliProdoti " +
                    "on article: {article} and commessa {commessa}", article, commessa);
                return null;
            }
        }
    }
}