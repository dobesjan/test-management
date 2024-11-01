using Microsoft.AspNetCore.Mvc;
using TestManagement.Api.Controllers.Abstract;
using TestManagement.DataAccess.Repository.TestCases;

namespace TestManagement.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EnvironmentController : WriteController<Models.TestCases.Environment>
	{
		public EnvironmentController(IEnvironmentRepository environmentRepository) : base(environmentRepository) { }
	}
}
