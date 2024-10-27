using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;
using TestManagement.Reporting.Shared.Attributes;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	public class TestSuiteExecutorAttribute : BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestSuiteAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Starting test suite: {attribute.SuiteName}");
			}
		}

		public override void After(MethodInfo methodUnderTest)
		{
			var attribute = (TestSuiteAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Completed test suite: {attribute.SuiteName}");
			}
		}
	}
}
