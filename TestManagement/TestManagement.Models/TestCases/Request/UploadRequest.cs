using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Models;
using TestManagement.Results.Trx.Models;

namespace TestManagement.Models.TestCases.Request
{
	public class UploadRequest
	{
		public List<ReportTestSuite> TestSuites { get; set; }

		public TestRun Results { get; set; }
	}
}
