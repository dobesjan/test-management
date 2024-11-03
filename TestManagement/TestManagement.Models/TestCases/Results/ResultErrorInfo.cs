using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases.Results
{
	public class ResultErrorInfo : Entity
	{
		public string? Message { get; set; }
		public string? StackTrace { get; set; }
	}
}
