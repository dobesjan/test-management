using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.DataAccess.Repository.Tasks.Relations
{
	public class TaskHasTestSuiteRepository : Repository<TaskHasTestSuite>, ITaskHasTestSuiteRepository
	{
		private readonly ITestSuiteRepository _testSuiteRepository;
		private readonly ITaskRepository _taskRepository;

		public TaskHasTestSuiteRepository(ApplicationDbContext context, ITestSuiteRepository testSuiteRepository, ITaskRepository taskRepository) : base(context)
		{
			_testSuiteRepository = testSuiteRepository;
			_taskRepository = taskRepository;
		}

		public void LinkTaskToTestSuite(int testSuiteId, int taskId)
		{
			if (!_testSuiteRepository.IsStored(testSuiteId))
			{
				throw new InvalidDataException("Test case not found!");
			}

			if (!_taskRepository.IsStored(taskId))
			{
				throw new InvalidDataException("Task not found!");
			}

			var entity = new TaskHasTestSuite
			{
				TestSuiteId = testSuiteId,
				TaskId = taskId
			};

			Add(entity);
			Save();
		}
	}
}
