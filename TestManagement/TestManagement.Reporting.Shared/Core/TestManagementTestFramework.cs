using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: Xunit.TestFramework("TestManagement.Reporting.Shared.Core", "TestManagement.Reporting.Shared")]
namespace TestManagement.Reporting.Shared.Core
{
	public class TestManagementTestFramework : XunitTestFramework
	{
		public TestManagementTestFramework(IMessageSink messageSink) : base(messageSink) { }
	}
}
