using Microsoft.AspNetCore.Mvc;
using TestManagement.DataAccess.Repository;
using TestManagement.Models;
using TestManagement.Models.TestCases;

namespace TestManagement.Api.Controllers.Abstract
{
	public abstract class WriteController<E> : ReadOnlyController<E> where E : IEntity
	{
		public WriteController(IRepository<E> repository) : base(repository) { }

		[HttpPost("Add")]
		public IActionResult Add([FromBody] E entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_repository.Add(entity);
			_repository.Save();

			return Ok(entity);
		}

		[HttpPost("Update")]
		public IActionResult Update([FromBody] E entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_repository.Update(entity);
			_repository.Save();

			return Ok(entity);
		}

		[HttpPost("Delete")]
		public IActionResult Delete([FromBody] E entity)
		{
			_repository.Remove(entity);
			_repository.Save();

			return Ok(entity);
		}
	}
}
