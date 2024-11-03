using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;
using TestManagement.Models.Tasks;
using TestManagement.Models.TestCases.Results;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Models.TestCases
{
	public class TestCase : Entity
	{
		public string Identifier { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public string MethodName { get; set; }

		public int TestSuiteId { get; set; }

		[ForeignKey(nameof(TestSuiteId))]
		public TestSuite TestSuite { get; set; }

		public bool AddedAutomatically { get; set; }

		public bool Automated { get; set; }

		public List<TestCaseHasTestLabel>? TestCaseHasTestLabel { get; set; }

		public List<TestCaseHasTestStep>? TestCaseHasTestSteps { get; set; }

		[InverseProperty(nameof(TestCase))]
		public List<TestCaseResult>? Results { get; set; }

		public List<TaskHasTestCase>? TaskHasTestCase { get; set; }

		public void UpdateFromReport(ReportTestCase reportTestCase)
		{
			Identifier = reportTestCase.Identifier;
			Name = reportTestCase.Name;
			Description = reportTestCase.Description;
			MethodName = reportTestCase.MethodName;
			AddedAutomatically = true;
		}
	}
}
