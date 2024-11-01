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
	public class TaskHasTestStepRepository : Repository<TaskHasTestStep>, ITaskHasTestStepRepository
	{
		private readonly ITaskRepository _taskRepository;
		private readonly ITestStepRepository _testStepRepository;

		public TaskHasTestStepRepository(ApplicationDbContext context, ITaskRepository taskRepository, ITestStepRepository testStepRepository) : base(context)
		{
			_taskRepository = taskRepository;
			_testStepRepository = testStepRepository;
		}

		public void LinkTaskToTestStep(int testStepId, int taskId)
		{
			if (!_testStepRepository.IsStored(testStepId))
			{
				throw new InvalidDataException("Test step not found!");
			}

			if (!_taskRepository.IsStored(taskId))
			{
				throw new InvalidDataException("Task not found!");
			}

			var entity = new TaskHasTestStep
			{
				TestStepId = testStepId,
				TaskId = taskId
			};

			Add(entity);
			Save();
		}
	}
}
