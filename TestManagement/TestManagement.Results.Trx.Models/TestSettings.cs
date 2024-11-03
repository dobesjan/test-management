using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class TestSettings
	{
		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("id")]
		public string Id { get; set; }

		[XmlElement("Deployment")]
		public Deployment Deployment { get; set; }
	}
}
