using Microsoft.AspNetCore.Mvc;
using TestManagement.DataAccess.Repository;
using TestManagement.Models;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers.Abstract
{
	public abstract class ReadOnlyController<E> : ControllerBase where E : IEntity
	{
		protected readonly IRepository<E> _repository;

		public ReadOnlyController(IRepository<E> repository)
		{
			_repository = repository;
		}

		[HttpGet("Get")]
		public IActionResult Get(int id)
		{
			var entity = _repository.Get(e => e.Id == id);
			if (entity == null)
			{
				return NotFound();
			}

			return Ok(entity);
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll(int offset, int limit)
		{
			var entities = _repository.GetAll(offset: offset, limit: limit);
			return Ok(entities);
		}

		[HttpGet("Count")]
		public IActionResult Count()
		{
			var count = _repository.Count();
			return Ok(count);
		}
	}
}
