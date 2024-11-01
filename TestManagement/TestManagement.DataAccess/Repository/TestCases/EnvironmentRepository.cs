using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;

namespace TestManagement.DataAccess.Repository.TestCases
{
	public class EnvironmentRepository : Repository<Models.TestCases.Environment>, IEnvironmentRepository
	{
		public EnvironmentRepository(ApplicationDbContext context) : base(context) { }
	}
}
