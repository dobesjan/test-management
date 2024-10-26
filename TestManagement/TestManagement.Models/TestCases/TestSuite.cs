using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases
{
	public class TestSuite : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
