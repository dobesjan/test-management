using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace TestManagement.Reporting.Shared.Core
{
    public class TestCompletionSink : IMessageSink
	{
		public bool OnMessage(IMessageSinkMessage message)
		{
			if (message is ITestAssemblyFinished)
			{
				TestReportManager.WriteReportToFile();
			}
			return true;
		}
	}
}
