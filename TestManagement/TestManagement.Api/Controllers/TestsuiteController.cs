using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestsuiteController : WriteController<TestSuite>
	{
		public TestsuiteController(ITestSuiteRepository repository) : base(repository) { }

		[HttpGet("GetForProject")]
		public IActionResult GetForProject(int id, int offset, int limit)
		{
			var suites = _repository.GetAll(filter: s => s.ProjectId.HasValue && s.ProjectId == id, offset: offset, limit: limit);
			return Ok(suites);
		}
	}
}
