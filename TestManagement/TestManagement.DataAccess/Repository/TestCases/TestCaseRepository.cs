using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.Models.TestCases;

namespace TestManagement.DataAccess.Repository.TestCases
{
	public class TestCaseRepository : Repository<TestCase>, ITestCaseRepository
	{
		public TestCaseRepository(ApplicationDbContext context) : base(context) 
		{
			this.properties = "TestSuite,TestCaseHasTestLabel.TestLabel,TestCaseResult,TestCaseHasTestStep.TestStep,TestCaseHasTestStep.TestStep.Results,TaskHasTestCase.Task";
		}
	}
}
