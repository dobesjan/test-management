using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
				Console.WriteLine($"Starting Step: {attribute.StepName}, Expected Result: {attribute.ExpectedResult}");
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
