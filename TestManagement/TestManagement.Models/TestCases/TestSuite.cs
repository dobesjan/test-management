using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases
{
	public class TestSuite : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public int? ProjectId { get; set; }

		[ForeignKey(nameof(ProjectId))]
		public Project? Project { get; set; }
	}
}
