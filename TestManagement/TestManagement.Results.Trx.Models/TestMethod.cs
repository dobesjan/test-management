using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class TestMethod
	{
		[XmlAttribute("codeBase")]
		public string CodeBase { get; set; }

		[XmlAttribute("adapterTypeName")]
		public string AdapterTypeName { get; set; }

		[XmlAttribute("className")]
		public string ClassName { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }
	}
}
