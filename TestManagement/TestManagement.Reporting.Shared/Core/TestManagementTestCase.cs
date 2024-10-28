using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TestManagement.Reporting.Shared.Core
{
	public class TestManagementTestCase : XunitTestCase
	{
		public TestManagementTestCase(IMessageSink diagnosticMessageSink, TestMethodDisplay defaultMethodDisplay, TestMethodDisplayOptions defaultMethodDisplayOptions, ITestMethod testMethod)
		: base(diagnosticMessageSink, defaultMethodDisplay, defaultMethodDisplayOptions, testMethod)
		{
		}

		public override async Task<RunSummary> RunAsync(IMessageSink diagnosticMessageSink, IMessageBus messageBus, object[] constructorArguments, ExceptionAggregator aggregator, CancellationTokenSource cancellationTokenSource)
		{
			var runner = new TestManagementTestCaseRunner(this, DisplayName, SkipReason, constructorArguments, TestMethodArguments, messageBus, aggregator, cancellationTokenSource);
			return await runner.RunAsync();
		}
	}
}
