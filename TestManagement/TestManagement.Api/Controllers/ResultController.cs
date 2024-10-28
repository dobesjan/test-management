using Microsoft.AspNetCore.Mvc;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ResultController : Controller
	{
		private readonly IProjectRepository _projectRepository;
		private readonly ITestSuiteRepository _testSuiteRepository;
		private readonly ITestCaseRepository _testCaseRepository;
		private readonly ITestStepRepository _stepRepository;

		private readonly ILogger<ResultController> _logger;

		public ResultController(
			IProjectRepository projectRepository,
			ITestSuiteRepository testSuiteRepository,
			ITestCaseRepository testCaseRepository,
			ITestStepRepository stepRepository,
			ILogger<ResultController> logger
			)
		{
			_projectRepository = projectRepository;
			_testSuiteRepository = testSuiteRepository;
			_testCaseRepository = testCaseRepository;
			_stepRepository = stepRepository;
			_logger = logger;
		}

		[HttpPost("Upload")]
		public IActionResult Upload([FromBody] List<ReportTestSuite> suites)
		{
			foreach (var suite in suites)
			{
				var project = _projectRepository.Get(suite.ProjectId);
				if (project != null)
				{
					TestSuite? testSuite = SaveTestSuite(suite);
					SaveTestCasesForSuite(suite, testSuite);
				}
				else
				{
					_logger.LogWarning($"Project with id '{suite.ProjectId}' does not exist!");
				}
			}

			return Ok();
		}

		private void SaveTestStepForTestCase(ReportTestCase reportTestCase, TestCase testCase)
		{
			if (reportTestCase.TestSteps != null)
			{
				foreach (var reportTestStep in reportTestCase.TestSteps)
				{
					var testStep = _stepRepository.Get(s => s.Identifier == reportTestStep.Identifier);

					if (testStep != null)
					{
						testStep.UpdateFromReport(reportTestStep);
						_stepRepository.Update(testStep);
					}
					else
					{
						testStep = new TestStep
						{
							Identifier = reportTestStep.Identifier,
							Name = reportTestStep.Name,
							Description = reportTestStep.Description
						};
						_stepRepository.Add(testStep);
					}

					_stepRepository.Save();
				}
			}
			
		}

		private void SaveTestCasesForSuite(ReportTestSuite suite, TestSuite testSuite)
		{
			if (suite.TestCases != null)
			{
				foreach (var reportTestCase in suite.TestCases)
				{
					var testCase = _testCaseRepository.Get(t => t.Identifier == reportTestCase.Identifier);

					if (testCase != null)
					{
						testCase.UpdateFromReport(reportTestCase);
						_testCaseRepository.Update(testCase);
					}
					else
					{
						testCase = new TestCase
						{
							Identifier = reportTestCase.Identifier,
							Name = reportTestCase.Name,
							Description = reportTestCase.Description,
							TestSuiteId = testSuite.Id
						};
						_testCaseRepository.Add(testCase);
					}

					_testCaseRepository.Save();

					SaveTestStepForTestCase(reportTestCase, testCase);
				}
			}
		}

		private TestSuite SaveTestSuite(ReportTestSuite suite)
		{
			var testSuite = _testSuiteRepository.Get(s => s.Identifier == suite.Identifier);
			if (testSuite != null)
			{
				testSuite.UpdateFromReport(suite);
				_testSuiteRepository.Update(testSuite);
			}
			else
			{
				testSuite = new TestSuite
				{
					Identifier = suite.Identifier,
					Name = suite.Name,
					Description = suite.Description,
					ProjectId = suite.ProjectId
				};
				_testSuiteRepository.Add(testSuite);
			}

			_testSuiteRepository.Save();
			return testSuite;
		}
	}
}
