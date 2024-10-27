using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;

namespace TestManagement.Models.TestCases
{
	public class TestSuiteHasLabel : Entity
	{
		public int TestSuiteId { get; set; }

		[ForeignKey(nameof(TestSuiteId))]
		public TestSuite TestSuite { get; set; }

		public int TestLabelId { get; set; }

		[ForeignKey(nameof(TestLabelId))]
		public TestLabel TestLabel { get; set; }
	}
}
