using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;
using TestManagement.Models.Teams;
using TestManagement.Models.TestCases;

namespace TestManagement.DataAccess.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Project> Projects { get; set; }
		public DbSet<TestSuite> TestSuites { get; set; }
		public DbSet<TestCase> TestCases { get; set; }

		public DbSet<TestCaseHasTestLabel> TestCaseHasTestLabel { get; set; }
		
		public DbSet<Team> Teams { get; set; }

		public DbSet<TestLabel> TestLabels { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TestCaseHasTestLabel>()
				.HasKey(pc => new { pc.TestCaseId, pc.TestLabelId });

			modelBuilder.Entity<TestCaseHasTestLabel>()
				.HasOne(pc => pc.TestCase)
				.WithMany(p => p.TestCaseHasTestLabel)
				.HasForeignKey(pc => pc.TestCaseId);

			modelBuilder.Entity<TestCaseHasTestLabel>()
				.HasOne(pc => pc.TestLabel)
				.WithMany(c => c.TestCaseHasTestLabel)
				.HasForeignKey(pc => pc.TestLabelId);

			modelBuilder.Entity<TestSuiteHasLabel>()
				.HasKey(pc => new { pc.TestSuiteId, pc.TestLabelId });

			modelBuilder.Entity<TestSuiteHasLabel>()
				.HasOne(pc => pc.TestSuite)
				.WithMany(p => p.TestSuiteHasLabels)
				.HasForeignKey(pc => pc.TestSuiteId);

			modelBuilder.Entity<TestSuiteHasLabel>()
				.HasOne(pc => pc.TestLabel)
				.WithMany(c => c.TestSuiteHasLabels)
				.HasForeignKey(pc => pc.TestLabelId);

			modelBuilder.Entity<ProjectHasTestLabel>()
				.HasKey(pc => new { pc.ProjectId, pc.TestLabelId });

			modelBuilder.Entity<ProjectHasTestLabel>()
				.HasOne(pc => pc.Project)
				.WithMany(p => p.ProjectHasTestLabels)
				.HasForeignKey(pc => pc.ProjectId);

			modelBuilder.Entity<ProjectHasTestLabel>()
				.HasOne(pc => pc.TestLabel)
				.WithMany(c => c.ProjectHasTestLabels)
				.HasForeignKey(pc => pc.TestLabelId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
