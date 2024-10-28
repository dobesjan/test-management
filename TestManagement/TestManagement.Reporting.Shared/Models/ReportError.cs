using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Models
{
	public class ReportError
	{
		public string Message { get; set; }
		public string? StackTrace { get; set; }
	}
}
