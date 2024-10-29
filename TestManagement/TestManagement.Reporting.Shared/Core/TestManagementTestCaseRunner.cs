using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Attributes;
using TestManagement.Reporting.Shared.Models;
using TestManagement.Reporting.Xunit.Attributes;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestManagement.Reporting.Shared.Core
{
	public class TestManagementTestCaseRunner : XunitTestCaseRunner
	{
		public TestManagementTestCaseRunner(IXunitTestCase testCase, string displayName, string skipReason, object[] constructorArguments, object[] testMethodArguments, IMessageBus messageBus, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
		: base(testCase, displayName, skipReason, constructorArguments, testMethodArguments, messageBus, aggregator, cancellationTokenSource)
		{
		}

		protected override async Task<RunSummary> RunTestAsync()
		{
			var summary = new RunSummary();

			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(TestMethod.DeclaringType, typeof(TestCaseAttribute));

			var currentTestCase = new ReportTestCase
			{
				Name = attribute.TestName,
				Identifier = attribute.Identifier,
				Description = attribute.Description,
				Status = TestCaseStatus.SUCCESS
			};

			var reports = GetTestStepReport(TestMethod);

			try
			{
				// Run the main test case.
				var result = await base.RunTestAsync();
				summary.Aggregate(result);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Test case failed: {TestMethod.Name}");

				currentTestCase.Status = TestCaseStatus.FAILED;

				var failedMethod = GetFailedStepFromStackTrace(ex);
				if (failedMethod != null)
				{
					Console.WriteLine($"Failed Step: {failedMethod.StepName}");
					Console.WriteLine($"Exception: {ex.Message}");
					Console.WriteLine($"Stack Trace: {ex.StackTrace}");

					var report = reports.FirstOrDefault(r => r.Identifier.Equals(failedMethod.Identifier));
					if (report != null)
					{
						report.Error = new ReportError
						{
							Message = ex.Message,
							StackTrace = ex.StackTrace
						};
					}
				}

				summary.Failed++;
			}

			currentTestCase.TestSteps = reports;

			var testSuiteAttribute = (TestSuiteAttribute)Attribute.GetCustomAttribute(TestClass.DeclaringType, typeof(TestSuiteAttribute));
			if (attribute != null)
			{
				var currentSuite = TestReportManager.TestSuites.FirstOrDefault(suite => suite.Identifier == attribute.Identifier);
				if (currentSuite == null)
				{
					var testSuite = new ReportTestSuite
					{
						Name = testSuiteAttribute.SuiteName,
						Identifier = testSuiteAttribute.Identifier,
						Description = testSuiteAttribute.Description,
						TestCases = new List<ReportTestCase>(),
						ProjectId = testSuiteAttribute.ProjectId
					};
					TestReportManager.TestSuites.Add(testSuite);
				}

				currentSuite?.TestCases.Add(currentTestCase);

				TestReportManager.AddTestSuite(currentSuite);
			}

			return summary;
		}

		private TestStepAttribute? GetFailedStepFromStackTrace(Exception ex)
		{
			// Parse the stack trace to locate the first method with a TestStep attribute.
			var stackTrace = new System.Diagnostics.StackTrace(ex, true);
			foreach (var frame in stackTrace.GetFrames() ?? Array.Empty<System.Diagnostics.StackFrame>())
			{
				var method = frame.GetMethod() as MethodInfo;
				return method?.GetCustomAttribute<TestStepAttribute>();
			}

			return null;
		}

		private List<ReportTestStep> GetTestStepReport(MethodInfo testMethod)
		{
			List<ReportTestStep> reports = new List<ReportTestStep>();

			var declaringType = testMethod.DeclaringType;
			if (declaringType != null)
			{
				// Find all methods with TestStep attribute within the test class
				var testStepMethods = declaringType.GetMethods()
					.Where(m => m.GetCustomAttribute<TestStepAttribute>() != null);

				// Iterate over each test step method to resolve information
				foreach (var stepMethod in testStepMethods)
				{
					var stepAttribute = stepMethod.GetCustomAttribute<TestStepAttribute>();
					if (stepAttribute != null)
					{
						Console.WriteLine($"Found Test Step: {stepAttribute.StepName}, ID: {stepAttribute.Identifier}");

						var testStep = new ReportTestStep
						{
							Name = stepAttribute.StepName,
							Identifier = stepAttribute.Identifier,
							Description = stepAttribute.ExpectedResult
						};

						reports.Add(testStep);
					}
				}
			}

			return reports;
		}
	}
}
