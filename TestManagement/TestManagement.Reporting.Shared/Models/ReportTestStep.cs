using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Models
{
	public class ReportTestStep
	{
		public string Identifier { get; set; }
		public string Name { get; set; }
		public string MethodName { get; set; }
		public string Description { get; set; }

		public ReportError? Error { get; set; }
	}
}
