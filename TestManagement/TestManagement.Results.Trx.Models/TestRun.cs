using System.Xml.Serialization;

namespace TestManagement.Results.Trx.Models
{
	[XmlRoot("TestRun", Namespace = "http://microsoft.com/schemas/VisualStudio/TeamTest/2010")]
	public class TestRun
	{
		[XmlAttribute("id")]
		public string Id { get; set; }

		[XmlAttribute("name")]
		public string Name { get; set; }

		[XmlAttribute("runUser")]
		public string RunUser { get; set; }

		[XmlElement("Times")]
		public Times Times { get; set; }

		[XmlElement("TestSettings")]
		public TestSettings TestSettings { get; set; }

		[XmlArray("Results")]
		[XmlArrayItem("UnitTestResult")]
		public List<UnitTestResult> Results { get; set; }

		[XmlArray("TestDefinitions")]
		[XmlArrayItem("UnitTest")]
		public List<UnitTest> TestDefinitions { get; set; }

		[XmlArray("TestEntries")]
		[XmlArrayItem("TestEntry")]
		public List<TestEntry> TestEntries { get; set; }

		[XmlArray("TestLists")]
		[XmlArrayItem("TestList")]
		public List<TestList> TestLists { get; set; }

		[XmlElement("ResultSummary")]
		public ResultSummary ResultSummary { get; set; }

		public static TestRun Deserialize(string filePath)
		{
			using (var reader = new StreamReader(filePath))
			{
				var serializer = new XmlSerializer(typeof(TestRun));
				return (TestRun)serializer.Deserialize(reader);
			}
		}

		public static TestRun DeserializeFromString(string xmlString)
		{
			using (var reader = new StringReader(xmlString))
			{
				var serializer = new XmlSerializer(typeof(TestRun), "http://microsoft.com/schemas/VisualStudio/TeamTest/2010");
				return (TestRun)serializer.Deserialize(reader);
			}
		}
	}
}
