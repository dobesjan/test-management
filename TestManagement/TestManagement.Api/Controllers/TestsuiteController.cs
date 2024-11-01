using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.Tasks.Relations;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TestsuiteController : WriteController<TestSuite>
	{
		private readonly ITaskHasTestSuiteRepository _taskHasTestSuiteRepository;

		public TestsuiteController(ITestSuiteRepository repository, ITaskHasTestSuiteRepository taskHasTestSuiteRepository) : base(repository) 
		{
			_taskHasTestSuiteRepository = taskHasTestSuiteRepository;
		}

		[HttpGet("GetForProject")]
		public IActionResult GetForProject(int id, int offset, int limit)
		{
			var suites = _repository.GetAll(filter: s => s.ProjectId.HasValue && s.ProjectId == id, offset: offset, limit: limit);
			return Ok(suites);
		}

		[HttpPost("LinkTask")]
		public IActionResult LinkTask(int testSuiteId, int taskId)
		{
			try
			{
				_taskHasTestSuiteRepository.LinkTaskToTestSuite(testSuiteId, taskId);
				return Ok();
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
