using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.Models.Tasks
{
	public class TaskHasTestCase : Entity
	{
		public int TaskId { get; set; }

		[ForeignKey(nameof(TaskId))]
		public Task Task { get; set; }

		public int TestCaseId { get; set; }

		[ForeignKey(nameof(TestCaseId))]
		public TestCase TestCase { get; set; }
	}
}
