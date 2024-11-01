using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.Models.Tasks
{
	public class Task : Entity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public string ProjectId { get; set; }

		[ForeignKey(nameof(ProjectId))]
		public Project Project { get; set; }

		public List<TaskHasTestCase>? TaskHasTestCase { get; set; }

		public List<TaskHasTestSuite>? TaskHasTestSuite { get; set; }
		public List<TaskHasTestStep>? TaskHasTestStep { get; set; }
	}
}
