using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Repository.Tasks;
using TestManagement.DataAccess.Repository.Tasks.Relations;
using TestManagement.DataAccess.Repository.Teams;
using TestManagement.DataAccess.Repository.TestCases;
using TestManagement.DataAccess.Repository.TestCases.Results;

namespace TestManagement.DataAccess.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<IProjectRepository, ProjectRepository>();
			services.AddScoped<ITestSuiteRepository, TestSuiteRepository>();
			services.AddScoped<ITestCaseRepository, TestCaseRepository>();
			services.AddScoped<ITestStepRepository, TestStepRepository>();

			services.AddScoped<ITestCaseResultRepository, TestCaseResultRepository>();
			services.AddScoped<ITestStepResultRepository, TestStepResultRepository>();

			services.AddScoped<ITeamRepository, TeamRepository>();

			services.AddScoped<ITaskRepository, TaskRepository>();
			services.AddScoped<ITaskHasTestCaseRepository, TaskHasTestCaseRepository>();
			services.AddScoped<ITaskHasTestStepRepository, TaskHasTestStepRepository>();
			services.AddScoped<ITaskHasTestSuiteRepository, TaskHasTestSuiteRepository>();

			return services;
		}
	}
}
