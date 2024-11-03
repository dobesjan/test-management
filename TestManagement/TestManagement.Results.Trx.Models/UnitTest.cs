using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class UnitTest
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("storage")]
		public string Storage { get; set; }

		[XmlAttribute("id")]
		public string Id { get; set; }

		[XmlElement("Execution")]
		public Execution Execution { get; set; }

		[XmlElement("TestMethod")]
		public TestMethod TestMethod { get; set; }
	}
}
