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
		public int ProjectId { get; }

		public TestSuiteAttribute(string suitName, string identifier, int projectId)
		{
			SuiteName = suitName;
			Identifier = identifier;
			ProjectId = projectId;
		}

		public TestSuiteAttribute(string suitName, string identifier, int projectId, string description)
		{
			SuiteName = suitName;
			Identifier = identifier;
			ProjectId = projectId;
			Description = description;
		}
	}
}
