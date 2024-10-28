using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Attributes;
using TestManagement.Reporting.Xunit.Attributes;

namespace TestManagement.Reporting.Xunit.Test
{
	[TestSuiteExecutor]
	[TestSuite("TestSuite2", "2", 1, "Testing suite 2")]
	public class TestSuite2
	{
		[Fact]
		[TestCase("Test 2", "2", "Testing test again")]
		[TestCaseExecutor]
		public async Task Test2()
		{
			await SayHello();
			await SayGoodbye();
		}

		[TestStep("Say hello", "100", "Says hello")]
		public async Task SayHello()
		{
			await Task.CompletedTask;
		}

		[TestStep("Say goodbye", "101", "Says goodbye")]
		public async Task SayGoodbye()
		{
			await Task.CompletedTask;
		}
	}
}
