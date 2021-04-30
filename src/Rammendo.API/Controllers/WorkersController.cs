using System;
using System.Collections.Generic;
using System.Linq;
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
    public class WorkersController : Controller
    {
        readonly IWorkersRepository _workersRepository;

        public WorkersController(IWorkersRepository workersRepository)
        {
            _workersRepository = workersRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Workers>> GetAllAsync()
        {
            try
            {
                var workers = await _workersRepository.GetWorkersAsync();
                Log.Debug("Successfully loaded workers on rammendo department");

                return workers;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error occurred while fetching the workers on rammendo department");
                return null;
            }
        }
    }
}