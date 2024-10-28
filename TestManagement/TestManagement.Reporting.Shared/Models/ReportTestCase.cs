using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Models
{
	public class ReportTestCase
	{
		public string Identifier { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<ReportTestStep> TestSteps { get; set; }
	}
}
