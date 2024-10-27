using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	public class TestCaseExecutorAttribute : BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Starting test: {attribute.TestName}");
			}
		}

		public override void After(MethodInfo methodUnderTest)
		{
			var attribute = (TestCaseAttribute)Attribute.GetCustomAttribute(methodUnderTest, typeof(TestStepAttribute));

			if (attribute != null)
			{
				Console.WriteLine($"Completed test: {attribute.TestName}");
			}
		}
	}
}
