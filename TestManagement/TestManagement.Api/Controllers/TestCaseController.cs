using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestCaseController : WriteController<TestCase>
	{
		public TestCaseController(ITestCaseRepository repository) : base(repository) { }

		[HttpGet("GetForTestSuite")]
		public ActionResult GetForTestSuite(int testSuiteId)
		{
			var testCases = _repository.GetAll(filter: t => t.TestSuiteId == testSuiteId);
			return Ok(testCases);
		}
	}
}
