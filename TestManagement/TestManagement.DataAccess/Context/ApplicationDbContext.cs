using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Models.Filters;
using TestManagement.Models.Teams;
using TestManagement.Models.TestCases;
using TestManagement.Models.TestCases.Results;

namespace TestManagement.DataAccess.Context
{
	public class ApplicationDbContext : DbContext
	{
		#region Test entities
		public DbSet<Project> Projects { get; set; }
		public DbSet<TestSuite> TestSuites { get; set; }
		public DbSet<TestCase> TestCases { get; set; }
		public DbSet<TestStep> TestSteps { get; set; }
		#endregion

		#region Test entities relations
		public DbSet<TestSuiteHasLabel> TestSuiteHasLabels { get; set; }
		public DbSet<TestCaseHasTestLabel> TestCaseHasTestLabel { get; set; }
		public DbSet<TestCaseHasTestStep> TestCaseHasTestSteps { get; set; }
		#endregion

		#region Results
		public DbSet<TestCaseResult> TestCaseResults { get; set; }
		public DbSet<TestStepResult> TestStepResults { get; set; }
		#endregion

		#region Teams
		public DbSet<Team> Teams { get; set; }
		#endregion

		#region Labels
		public DbSet<TestLabel> TestLabels { get; set; }
		#endregion

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

			modelBuilder.Entity<TestCaseHasTestStep>()
				.HasKey(pc => new { pc.TestCaseId, pc.TestStepId });

			modelBuilder.Entity<TestCaseHasTestStep>()
				.HasOne(pc => pc.TestCase)
				.WithMany(p => p.TestCaseHasTestSteps)
				.HasForeignKey(pc => pc.TestCaseId);

			modelBuilder.Entity<TestCaseHasTestStep>()
				.HasOne(pc => pc.TestStep)
				.WithMany(c => c.TestCaseHasTestSteps)
				.HasForeignKey(pc => pc.TestStepId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
