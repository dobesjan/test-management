using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Attributes
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class TestSuiteAttribute : Attribute
	{
		public string SuiteName { get; }
		public string Identifier { get; }
		public string Description { get; }

		public TestSuiteAttribute(string suitName, string identifier)
		{
			SuiteName = suitName;
			Identifier = identifier;
		}

		public TestSuiteAttribute(string suitName, string identifier, string description)
		{
			SuiteName = suitName;
			Identifier = identifier;
			Description = description;
		}
	}
}
