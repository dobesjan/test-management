using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Models.TestCases
{
	public class TestCase : Entity
	{
		public string Identifier { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public int TestSuiteId { get; set; }

		[ForeignKey(nameof(TestSuiteId))]
		public TestSuite TestSuite { get; set; }

		public List<TestCaseHasTestLabel>? TestCaseHasTestLabel { get; set; }

		public List<TestCaseHasTestStep>? TestCaseHasTestSteps { get; set; }

		public void UpdateFromReport(ReportTestCase reportTestCase)
		{
			Identifier = reportTestCase.Identifier;
			Name = reportTestCase.Name;
			Description = reportTestCase.Description;
		}
	}
}
