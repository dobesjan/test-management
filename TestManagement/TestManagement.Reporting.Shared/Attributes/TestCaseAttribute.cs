using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TestManagement.Reporting.Xunit.Attributes
{
	[XunitTestCaseDiscoverer("TestManagement.Reporting.Shared.Core.TestManagementDiscoverer", "TestManagement.Reporting.Shared")]
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class TestCaseAttribute : Attribute
	{
		public string TestName { get; }
		public string Identifier { get; }
		public string Description { get; }

		public TestCaseAttribute(string testName, string identifier)
		{
			TestName = testName;
			Identifier = identifier;
		}

		public TestCaseAttribute(string testName, string identifier, string description)
		{
			TestName = testName;
			Identifier = identifier;
			Description = description;
		}
	}
}
