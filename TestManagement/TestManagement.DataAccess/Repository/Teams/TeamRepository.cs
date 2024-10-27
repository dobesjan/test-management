using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Context;
using TestManagement.Models.Teams;

namespace TestManagement.DataAccess.Repository.Teams
{
	public class TeamRepository : Repository<Team>, ITeamRepository
	{
		public TeamRepository(ApplicationDbContext context) : base(context) { }
	}
}
