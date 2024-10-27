using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;

namespace TestManagement.Models.TestCases
{
	public class TestCase : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int TestSuiteId { get; set; }

		[ForeignKey(nameof(TestSuiteId))]
		public TestSuite Suite { get; set; }

		public List<TestCaseHasTestLabel>? TestCaseHasTestLabel { get; set; }
	}
}
