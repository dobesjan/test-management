using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.DataAccess.Repository.Teams;
using TestManagement.DataAccess.Repository.TestCases;

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

			services.AddScoped<ITeamRepository, TeamRepository>();

			return services;
		}
	}
}
