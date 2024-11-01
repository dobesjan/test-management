using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Tasks;

namespace TestManagement.DataAccess.Repository.Tasks.Relations
{
	public interface ITaskHasTestStepRepository : IRepository<TaskHasTestStep>
	{
		public void LinkTaskToTestStep(int testStepId, int taskId);
	}
}
