using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.Tasks.Relations;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestCaseController : WriteController<TestCase>
	{
		private readonly ITaskHasTestCaseRepository _taskHasTestCaseRepository;

		public TestCaseController(ITestCaseRepository repository, ITaskHasTestCaseRepository taskHasTestCaseRepository) : base(repository) 
		{
			_taskHasTestCaseRepository = taskHasTestCaseRepository;
		}

		[HttpGet("GetForTestSuite")]
		public ActionResult GetForTestSuite(int testSuiteId)
		{
			var testCases = _repository.GetAll(filter: t => t.TestSuiteId == testSuiteId);
			return Ok(testCases);
		}

		[HttpPost("LinkTask")]
		public IActionResult LinkTask(int testCaseId, int taskId)
		{
			try
			{
				_taskHasTestCaseRepository.LinkTaskToTestCase(testCaseId, taskId);
				return Ok();
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
