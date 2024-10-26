using Microsoft.AspNetCore.Mvc;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestsuiteController : Controller
	{
		[HttpGet(Name = "Get")]
		public IActionResult Get(int projectId)
		{
			throw new NotImplementedException();
		}

		[HttpGet(Name = "GetAll")]
		public IActionResult GetAll(int offset, int limit)
		{
			throw new NotImplementedException();
		}

		[HttpGet(Name = "GetForProject")]
		public IActionResult GetForProject(int offset, int limit)
		{
			throw new NotImplementedException();
		}

		[HttpGet(Name = "Count")]
		public IActionResult Count()
		{
			throw new NotImplementedException();
		}

		[HttpPost(Name = "Add")]
		public IActionResult Add([FromBody] Project project)
		{
			throw new NotImplementedException();
		}

		[HttpPost(Name = "Update")]
		public IActionResult Update([FromBody] Project project)
		{
			throw new NotImplementedException();
		}

		[HttpPost(Name = "Delete")]
		public IActionResult Delete([FromBody] Project project)
		{
			throw new NotImplementedException();
		}
	}
}
