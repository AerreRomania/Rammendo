using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rammendo.Data.Repositories.Interfaces;
using Serilog;

namespace Rammendo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly ILoginRepository _loginRepository;

		public LoginController(ILoginRepository loginRepository) {
			_loginRepository = loginRepository;
		}

		[HttpPost]
		public async Task<IActionResult> LoginAsync(string codAngajat) {

			IActionResult response = Unauthorized();
			
			try {
				var angajatis = await _loginRepository.GetAngajatis(codAngajat);
				var angajat = angajatis.FirstOrDefault();
				Log.Debug("{UserCount} users found for CodAngajat {CodAngajat}", angajatis.ToList().Count, angajat.CodAngajat);

				if (angajatis != null) {
					//var angajat = angajatis.FirstOrDefault();
					var strUserId = angajat.Id.ToString();
					Log.Debug("User {Angajat} authenticated for CodAngajat {CodAngajat}", angajat.Angajat, angajat.CodAngajat);
					response = Ok(angajat);
				}
			}
			catch (ArgumentException ae) {
				Log.Debug(ae, "No access for CodAngajat {CodAngajat}", codAngajat);
				return Unauthorized(ae.Message);
			}
			catch (Exception ex) {
				Log.Error(ex, "An unexpected error occurred while user login");
				return StatusCode((int)HttpStatusCode.InternalServerError, ex.ToString());
			}

			return response;
		}
	}
}