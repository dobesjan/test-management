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
			}
		}
	}
}
