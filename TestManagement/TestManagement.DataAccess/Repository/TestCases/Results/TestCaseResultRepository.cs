using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.Models.TestCases.Results;

namespace TestManagement.DataAccess.Repository.TestCases.Results
{
	public class TestCaseResultRepository : Repository<TestCaseResult>, ITestCaseResultRepository
	{
		public TestCaseResultRepository(ApplicationDbContext context) : base(context) { }
	}
}
