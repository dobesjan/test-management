using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class Counters
	{
		[XmlAttribute("total")]
		public int Total { get; set; }

		[XmlAttribute("executed")]
		public int Executed { get; set; }

		[XmlAttribute("passed")]
		public int Passed { get; set; }

		[XmlAttribute("failed")]
		public int Failed { get; set; }
	}
}
