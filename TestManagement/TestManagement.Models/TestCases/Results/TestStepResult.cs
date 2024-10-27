using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases.Results
{
	public enum TestStepRunResult
	{
		SUCCESS = 1,
		FAILURE = 2
	}

	public class TestStepResult : Entity
	{
		public int TestStepId { get; set; }

		[ForeignKey(nameof(TestStepId))]
		public TestStep TestStep { get; set; }

		public int TestStepRunResult { get; set; }
	}
}
