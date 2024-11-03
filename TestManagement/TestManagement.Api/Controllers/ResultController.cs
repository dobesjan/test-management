using Microsoft.AspNetCore.Mvc;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.DataAccess.Repository.TestCases.Results;
using TestManagement.Models.TestCases;
using TestManagement.Models.TestCases.Request;
using TestManagement.Models.TestCases.Results;
using TestManagement.Reporting.Shared.Models;
using TestManagement.Results.Trx.Models;

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
		private readonly ITestCaseResultRepository _testCaseResultRepository;
		private readonly ITestStepResultRepository _stepResultRepository;


		private readonly ILogger<ResultController> _logger;

		public ResultController(
			IProjectRepository projectRepository,
			ITestSuiteRepository testSuiteRepository,
			ITestCaseRepository testCaseRepository,
			ITestStepRepository stepRepository,
			ITestCaseResultRepository testCaseResultRepository,
			ITestStepResultRepository stepResultRepository,
			ILogger<ResultController> logger
			)
		{
			_projectRepository = projectRepository;
			_testSuiteRepository = testSuiteRepository;
			_testCaseRepository = testCaseRepository;
			_stepRepository = stepRepository;
			_testCaseResultRepository = testCaseResultRepository;
			_stepResultRepository = stepResultRepository;
			_logger = logger;
		}

		[HttpPost("Upload")]
		public IActionResult Upload([FromBody] UploadRequest uploadRequest)
		{
			foreach (var suite in uploadRequest.TestSuites)
			{
				var project = _projectRepository.Get(suite.ProjectId);
				if (project != null)
				{
					TestSuite? testSuite = SaveTestSuite(suite);
					SaveTestCasesForSuite(suite, testSuite, uploadRequest.Results);
				}
				else
				{
					_logger.LogWarning($"Project with id '{suite.ProjectId}' does not exist!");
				}
			}

			return Ok();
		}

		[HttpGet("GetForTestCase")]
		public IActionResult GetForTestCase(int testCaseId, int offset, int limit)
		{
			var results = _testCaseResultRepository.GetAll(r => r.TestCaseId == testCaseId);
			return Ok(results);
		}

		[HttpGet("GetForTestStep")]
		public IActionResult GetForTestStep(int testStepId, int offset, int limit)
		{
			var results = _stepResultRepository.GetAll(r => r.TestStepId == testStepId);
			return Ok(results);
		}

		#region Upload test results
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

		private void SaveTestCasesForSuite(ReportTestSuite suite, TestSuite testSuite, TestRun testRun)
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
					SaveTestResultsForTestCase(testRun, testCase);

					SaveTestStepForTestCase(reportTestCase, testCase);
				}
			}
		}

		private void SaveTestResultsForTestCase(TestRun testRun, TestCase testCase)
		{
			if (testRun != null && testRun.Results != null)
			{
				var result = testRun.Results.FirstOrDefault(r => r.TestName == testCase.MethodName);
				if (result != null)
				{
					var testCaseResult = TestCaseResult.FromUnitTestResult(testCase.Id, result);

					_testCaseResultRepository.Add(testCaseResult);
					_testCaseResultRepository.Save();
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

		#endregion
	}
}
