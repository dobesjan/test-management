using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.Models.TestCases;

namespace TestManagement.DataAccess.Repository.TestCases
{
	public class TestSuiteRepository : Repository<TestSuite>, ITestSuiteRepository
	{
		public TestSuiteRepository(ApplicationDbContext context) : base(context) 
		{
			this.properties = "TestCases,TestCases.TestLabel,TestCases.Results,TestCases.TestCaseHasTestSteps.TestStep,TestCases.TestCaseHasTestSteps.TestStep.Results,TestCases.TestCaseHasTestLabel.TestLabel,Project,TestSuiteHasLabels.TestLabel";
		}
	}
}
