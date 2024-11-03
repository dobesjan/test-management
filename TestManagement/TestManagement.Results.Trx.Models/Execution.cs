using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class Execution
	{
		[XmlAttribute("id")]
		public string Id { get; set; }
	}
}
