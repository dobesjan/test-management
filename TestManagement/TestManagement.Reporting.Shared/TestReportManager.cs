using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Reporting.Shared
{
	public static class TestReportManager
	{
		public static List<ReportTestSuite> TestSuites = new List<ReportTestSuite>();

		public static void WriteReportToFile()
		{
			string json = JsonConvert.SerializeObject(TestSuites, Formatting.Indented);
			File.WriteAllText("TestReport.json", json);
		}
	}
}
