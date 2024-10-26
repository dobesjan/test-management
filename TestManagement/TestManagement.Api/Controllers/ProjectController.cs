using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProjectController : WriteController<Project>
	{
		private readonly ILogger<ProjectController> _logger;

		public ProjectController(ILogger<ProjectController> logger, IProjectRepository repository) : base(repository)
		{
			_logger = logger;
		}
	}
}
