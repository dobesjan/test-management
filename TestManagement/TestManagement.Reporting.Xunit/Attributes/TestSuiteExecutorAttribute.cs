using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;
using TestManagement.Reporting.Shared;
using TestManagement.Reporting.Shared.Attributes;
using TestManagement.Reporting.Shared.Models;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	public class TestSuiteExecutorAttribute : BeforeAfterTestAttribute
	{
		public override void Before(MethodInfo methodUnderTest)
		{
			var attribute = (TestSuiteAttribute)Attribute.GetCustomAttribute(methodUnderTest.DeclaringType, typeof(TestSuiteAttribute));

			if (attribute != null)
			{
				var existingSuite = TestReportManager.TestSuites
				.FirstOrDefault(suite => suite.Identifier == attribute.Identifier);

				if (existingSuite == null)
				{
					var testSuite = new ReportTestSuite
					{
						Name = attribute.SuiteName,
						Identifier = attribute.Identifier,
						Description = attribute.Description,
						TestCases = new List<ReportTestCase>(),
						ProjectId = attribute.ProjectId
					};
					TestReportManager.TestSuites.Add(testSuite);
				}
			}
		}

		public override void After(MethodInfo methodUnderTest)
		{
			TestReportManager.WriteReportToFile();
		}
	}
}
