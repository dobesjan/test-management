using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;
using TestManagement.Reporting.Shared;
using TestManagement.Reporting.Shared.Models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	public class TestCaseExecutorAttribute : BeforeAfterTestAttribute
	{
		private DateTime _startTime;
		private ReportTestSuite _currentSuite;
		private ReportTestCase _currentTestCase;
		private bool _passed = true;

		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestCaseAttribute));

			if (attribute != null)
			{
				_currentTestCase = new ReportTestCase
				{
					Name = attribute.TestName,
					Identifier = attribute.Identifier,
					Description = attribute.Description,
					Status = TestCaseStatus.SUCCESS
				};
				_currentSuite = TestReportManager.TestSuites.LastOrDefault();
				_currentSuite?.TestCases.Add(_currentTestCase);
			}
		}

		public override void After(MethodInfo methodUnderTest)
		{
			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestCaseAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Completed test: {attribute.TestName}");

				// Get the declaring type to find all methods with TestStep attribute
				var declaringType = methodUnderTest.DeclaringType;
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

							// Link the test step to the current test case
							if (_currentTestCase != null)
							{
								if (_currentTestCase.TestSteps == null)
								{
									_currentTestCase.TestSteps = new List<ReportTestStep>();
								}

								_currentTestCase.TestSteps.Add(testStep);
							}
						}
					}
				}
			}
		}
	}
}
