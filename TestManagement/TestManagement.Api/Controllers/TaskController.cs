using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.Tasks;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TaskController : WriteController<Models.Tasks.Task>
	{
		public TaskController(ITaskRepository taskRepository) : base(taskRepository) { }
	}
}
