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
	public class TestCaseExecutorAttribute : BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestCaseAttribute));

			if (attribute != null)
			{
				var testCase = new TestCase
				{
					Name = attribute.TestName,
					Identifier = attribute.Identifier,
					Description = attribute.Description
				};
				var currentSuite = TestReportManager.TestSuites.LastOrDefault();
				currentSuite?.TestCases.Add(testCase);
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

							// Here, you could add the test step information to the report or log it
							var currentTestCase = TestReportManager.TestSuites
												  .LastOrDefault()?.TestCases.LastOrDefault();

							var testStep = new TestStep
							{
								Name = stepAttribute.StepName,
								Identifier = stepAttribute.Identifier,
								Description = stepAttribute.ExpectedResult
							};

							// Link the test step to the current test case
							if (currentTestCase != null)
							{
								if (currentTestCase.TestCaseHasTestSteps == null)
								{
									currentTestCase.TestCaseHasTestSteps = new List<TestCaseHasTestStep>();
								}

								TestCaseHasTestStep relation = new TestCaseHasTestStep
								{
									//TestCase = currentTestCase,
									TestStep = testStep
								};

								currentTestCase.TestCaseHasTestSteps.Add(relation);
							}
						}
					}
				}
			}
		}
	}
}
