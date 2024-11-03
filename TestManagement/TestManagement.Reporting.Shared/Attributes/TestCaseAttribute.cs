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
		public string MethodName { get; }
		public string Identifier { get; }
		public string Description { get; }

		public TestCaseAttribute(string testName, string identifier, string description = "", [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
		{
			TestName = testName;
			Identifier = identifier;
			MethodName = methodName;
			Description = description;
		}
	}
}
