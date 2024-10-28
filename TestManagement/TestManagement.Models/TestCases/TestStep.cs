using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Models.TestCases
{
	public class TestStep : Entity
	{
		// Used for identify step
		public string Identifier { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<TestCaseHasTestStep>? TestCaseHasTestSteps { get; set; }

		public void UpdateFromReport(ReportTestStep reportTestStep)
		{
			Name = reportTestStep.Name;
			Description = reportTestStep.Description;
		}
	}
}
