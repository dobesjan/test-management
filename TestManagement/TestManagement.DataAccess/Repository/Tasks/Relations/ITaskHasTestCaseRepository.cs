using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Tasks;

namespace TestManagement.DataAccess.Repository.Tasks.Relations
{
	public interface ITaskHasTestCaseRepository : IRepository<TaskHasTestCase>
	{
		public void LinkTaskToTestCase(int testCaseId, int taskId);
	}
}
