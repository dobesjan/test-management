using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.Models.Filters
{
	public class TestLabel : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsSystem { get; set; }

		public List<TestCaseHasTestLabel>? TestCaseHasTestLabel { get; set; }

		public List<TestSuiteHasLabel>? TestSuiteHasLabels { get; set; }

		public List<ProjectHasTestLabel>? ProjectHasTestLabels { get; set; }
	}
}
