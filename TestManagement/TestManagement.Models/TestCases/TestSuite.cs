using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Shared.Models;

namespace TestManagement.Models.TestCases
{
	public class TestSuite : Entity
	{
		public string Identifier { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }

		public int? ProjectId { get; set; }

		[ForeignKey(nameof(ProjectId))]
		public Project? Project { get; set; }

		[InverseProperty(nameof(TestSuite))]
		[ValidateNever]
		public List<TestCase>? TestCases { get; set; }

		public List<TestSuiteHasLabel>? TestSuiteHasLabels { get; set; }

		public void UpdateFromReport(ReportTestSuite reportTestSuite)
		{
			Name = reportTestSuite.Name;
			Description = reportTestSuite.Description;
			ProjectId = reportTestSuite.ProjectId;
		}

		public static TestSuite FromReportTestSuite(ReportTestSuite reportTestSuite)
		{
			var testSuite = new TestSuite
			{
				Identifier = reportTestSuite.Identifier,
				Name = reportTestSuite.Name,
				Description = reportTestSuite.Description,
				TestCases = new List<TestCase>(),
				TestSuiteHasLabels = new List<TestSuiteHasLabel>(),
				ProjectId = reportTestSuite.ProjectId,
			};

			if (testSuite.TestCases != null)
			{
				foreach (var reportTestCase in reportTestSuite.TestCases)
				{
					var testCase = new TestCase
					{
						Identifier = reportTestCase.Identifier,
						Name = reportTestCase.Name,
						Description = reportTestCase.Description,
						TestCaseHasTestSteps = new List<TestCaseHasTestStep>()
					};

					if (reportTestCase.TestSteps != null)
					{
						foreach (var reportTestStep in reportTestCase.TestSteps)
						{
							var testStep = new TestStep
							{
								Identifier = reportTestStep.Identifier,
								Name = reportTestStep.Name,
								Description = reportTestStep.Description,
							};

							var relation = new TestCaseHasTestStep
							{
								TestCase = testCase,
								TestStep = testStep
							};

							testCase.TestCaseHasTestSteps.Add(relation);
						}
					}

					testSuite.TestCases.Add(testCase);
				}
			}

			return testSuite;
		}
	}
}
