using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.TestCases;

namespace TestManagement.DataAccess.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Project> Projects { get; set; }
		public DbSet<TestSuite> TestSuites { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
	}
}
