using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases
{
	public class TestStep : Entity
	{
		// Used for identify step
		public int StepIdentifier { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public List<TestCaseHasTestStep>? TestCaseHasTestSteps { get; set; }
	}
}
