using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestManagement.Reporting.Shared.Core
{
	public class TestManagementDiscoverer : IXunitTestCaseDiscoverer
	{
		private readonly IMessageSink diagnosticMessageSink;

		public TestManagementDiscoverer(IMessageSink diagnosticMessageSink)
		{
			this.diagnosticMessageSink = diagnosticMessageSink;
		}

		public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
		{
			yield return new TestManagementTestCase(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), TestMethodDisplayOptions.None, testMethod);
		}
	}
}
