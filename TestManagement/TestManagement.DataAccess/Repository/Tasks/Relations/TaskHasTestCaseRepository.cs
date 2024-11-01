using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.Tasks;

namespace TestManagement.DataAccess.Repository.Tasks.Relations
{
	public class TaskHasTestCaseRepository : Repository<TaskHasTestCase>, ITaskHasTestCaseRepository
	{
		private readonly ITestCaseRepository _testCaseRepository;
		private readonly ITaskRepository _taskRepository;

		public TaskHasTestCaseRepository(ApplicationDbContext context, ITestCaseRepository testCaseRepository, ITaskRepository taskRepository) : base(context) 
		{
			_testCaseRepository = testCaseRepository;
			_taskRepository = taskRepository;
		}

		public void LinkTaskToTestCase(int testCaseId, int taskId)
		{
			if (!_testCaseRepository.IsStored(testCaseId))
			{
				throw new InvalidDataException("Test case not found!");
			}

			if (!_taskRepository.IsStored(taskId))
			{
				throw new InvalidDataException("Task not found!");
			}

			var entity = new TaskHasTestCase
			{
				TestCaseId = testCaseId,
				TaskId = taskId
			};

			Add(entity);
			Save();
		}
	}
}
