using System;
using System.Collections.Generic;
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

		public string TestName { get; set; }

		public List<TestCaseHasTestLabel>? TestCaseHasTestLabel { get; set; }
	}
}
