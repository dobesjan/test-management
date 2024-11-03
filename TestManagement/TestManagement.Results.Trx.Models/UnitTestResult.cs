using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class UnitTestResult
	{
		[XmlAttribute("executionId")]
		public string ExecutionId { get; set; }

		[XmlAttribute("testId")]
		public string TestId { get; set; }

		[XmlAttribute("testName")]
		public string TestName { get; set; }

		[XmlAttribute("computerName")]
		public string ComputerName { get; set; }

		[XmlAttribute("duration")]
		public string Duration { get; set; }

		[XmlAttribute("startTime")]
		public DateTime StartTime { get; set; }

		[XmlAttribute("endTime")]
		public DateTime EndTime { get; set; }

		[XmlAttribute("testType")]
		public string TestType { get; set; }

		[XmlAttribute("outcome")]
		public string Outcome { get; set; }

		[XmlAttribute("testListId")]
		public string TestListId { get; set; }

		[XmlElement("Output")]
		public Output Output { get; set; }
	}
}
