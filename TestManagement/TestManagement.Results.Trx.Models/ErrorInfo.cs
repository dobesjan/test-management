using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	public class ErrorInfo
	{
		[XmlElement("Message")]
		public string Message { get; set; }

		[XmlElement("StackTrace")]
		public string StackTrace { get; set; }
	}
}
