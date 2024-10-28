using Microsoft.AspNetCore.Mvc;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ResultController : Controller
	{
		[HttpPost("Upload")]
		public IActionResult Upload([FromBody] List<ReportTestSuite> suites)
		{
			
			return Ok();
		}
	}
}
