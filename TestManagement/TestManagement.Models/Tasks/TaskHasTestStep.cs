using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.Models.Tasks
{
	public class TaskHasTestStep : Entity
	{
		public int TaskId { get; set; }

		[ForeignKey(nameof(TaskId))]
		public Task Task { get; set; }

		public int TestStepId { get; set; }

		[ForeignKey(nameof(TestStepId))]
		public TestStep TestStep { get; set; }
	}
}
