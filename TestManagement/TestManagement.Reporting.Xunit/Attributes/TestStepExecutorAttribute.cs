using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;
using TestManagement.Reporting.Shared;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	public class TestStepExecutorAttribute : BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestStepAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				var testStep = new TestStep
				{
					Name = attribute.StepName,
					Identifier = attribute.Identifier,
					Description = attribute.ExpectedResult
				};

				var currentTestCase = TestReportManager.TestSuites
										.LastOrDefault()?.TestCases.LastOrDefault();

				TestCaseHasTestStep relation = new TestCaseHasTestStep
				{
					TestCase = currentTestCase,
					TestStep = testStep
				};

				if (currentTestCase.TestCaseHasTestSteps == null)
				{
					currentTestCase.TestCaseHasTestSteps = new List<TestCaseHasTestStep>();
				}

				currentTestCase.TestCaseHasTestSteps.Add(relation);
			}
		}

		public override void After(MethodInfo methodUnderTest)
		{
			var attribute = (TestStepAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Completed Step: {attribute.StepName}");
			}
		}
	}
}
