using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Tasks;

namespace TestManagement.DataAccess.Repository.Tasks.Relations
{
	public interface ITaskHasTestSuiteRepository : IRepository<TaskHasTestSuite>
	{
		public void LinkTaskToTestSuite(int testSuiteId, int taskId);
	}
}
