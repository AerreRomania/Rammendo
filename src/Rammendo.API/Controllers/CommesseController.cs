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
    public class CommesseController : Controller
    {
        readonly ICommesseRepository _commesseRepository;

        public CommesseController(ICommesseRepository commesseRepository) {
            _commesseRepository = commesseRepository;
        }

        [HttpPost]
        public async Task<Commesse> GetCommessaAsync(string barcode)
        {
            try {
                var commessa = await _commesseRepository.GetAsync(barcode);  
                Log.Debug("Successfully loaded commessa {commessa}", commessa);

                return commessa;
            }
            catch (Exception ex) {     
                Log.Error(ex, "An unexpected error occurred while fetching the commessa on barcode {barcode}", barcode);
                return null;
            }
        } 
    }
}