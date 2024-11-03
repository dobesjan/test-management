using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Tasks;
using TestManagement.Models.TestCases.Results;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Models.TestCases
{
	public class TestStep : Entity
	{
		// Used for identify step
		public string Identifier { get; set; }

		public string Name { get; set; }

		public string MethodName { get; set; }

		public string Description { get; set; }

		public bool AddedAutomatically { get; set; }

		public List<TestCaseHasTestStep>? TestCaseHasTestSteps { get; set; }

		public List<TaskHasTestStep>? TaskHasTestStep { get; set; }

		[InverseProperty(nameof(TestStep))]
		public List<TestStepResult>? Results { get; set; }

		public void UpdateFromReport(ReportTestStep reportTestStep)
		{
			Name = reportTestStep.Name;
			MethodName = reportTestStep.MethodName;
			Description = reportTestStep.Description;
			AddedAutomatically = true;
		}
	}
}
