using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class TestEntry
	{
		[XmlAttribute("testId")]
		public string TestId { get; set; }

		[XmlAttribute("executionId")]
		public string ExecutionId { get; set; }

		[XmlAttribute("testListId")]
		public string TestListId { get; set; }
	}
}
