using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.Models.TestCases.Results;

namespace TestManagement.DataAccess.Repository.TestCases.Results
{
	public class TestStepResultRepository : Repository<TestStepResult>, ITestStepResultRepository
	{
		public TestStepResultRepository(ApplicationDbContext context) : base(context) { }
	}
}
