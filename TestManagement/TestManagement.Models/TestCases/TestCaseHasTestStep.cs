using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases
{
	public class TestCaseHasTestStep : Entity
	{
		public int TestCaseId { get; set; }

		[ForeignKey(nameof(TestCaseId))]
		public TestCase TestCase { get; set; }

		public int TestStepId { get; set; }

		[ForeignKey(nameof(TestStepId))]
		public TestStep TestStep { get; set; }
	}
}
