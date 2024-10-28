using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Models
{
	public class ReportTestSuite
	{
		public string Identifier { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int ProjectId { get; set; }
		public List<ReportTestCase> TestCases { get; set; }
	}
}
