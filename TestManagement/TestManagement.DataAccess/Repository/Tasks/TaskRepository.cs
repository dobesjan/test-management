using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;

namespace TestManagement.DataAccess.Repository.Tasks
{
	public class TaskRepository : Repository<Models.Tasks.Task>, ITaskRepository
	{
		public TaskRepository(ApplicationDbContext context) : base(context) 
		{
			this.properties = "TaskHasTestCase.TestCase,TaskHasTestSuite.TestSuite,TaskHasTestStep.TestStep";
		}
	}
}
