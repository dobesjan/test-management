using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.Tasks.Relations;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TeststepController : WriteController<TestStep>
    {
		private readonly ITaskHasTestStepRepository _taskHasTestStepRepository;

		public TeststepController(ITaskHasTestStepRepository taskHasTestStepRepository, ITestStepRepository testStepRepository) : base(testStepRepository)
		{
			_taskHasTestStepRepository = taskHasTestStepRepository;
		}

		[HttpPost("LinkTask")]
		public IActionResult LinkTask(int testStepId, int taskId)
		{
			try
			{
				_taskHasTestStepRepository.LinkTaskToTestStep(testStepId, taskId);
				return Ok();
			}
			catch (InvalidDataException ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
