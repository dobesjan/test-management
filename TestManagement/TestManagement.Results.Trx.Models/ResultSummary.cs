using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class ResultSummary
	{
		[XmlAttribute("outcome")]
		public string Outcome { get; set; }

		[XmlElement("Counters")]
		public Counters Counters { get; set; }

		[XmlElement("Output")]
		public Output Output { get; set; }
	}
}
