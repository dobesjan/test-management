using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Reporting.Xunit.Attributes;
using Xunit;

namespace TestManagement.Reporting.Xunit.Fixtures
{
	public class TestStepsFixture : IAsyncLifetime
	{
		private readonly object _testClassInstance;

		public TestStepsFixture(Type testClassType)
		{
			_testClassInstance = Activator.CreateInstance(testClassType);
		}

		public async Task InitializeAsync()
		{
			await ExecuteTestSteps();
		}

		public Task DisposeAsync() => Task.CompletedTask;

		private async Task ExecuteTestSteps()
		{
			var methods = _testClassInstance.GetType().GetMethods();

			foreach (var method in methods)
			{
				var attribute = (TestStepAttribute)Attribute.GetCustomAttribute(method, typeof(TestStepAttribute));
				if (attribute != null)
				{
					await ExecuteStepWithLogging(method, attribute);
				}
			}
		}

		private async Task ExecuteStepWithLogging(MethodInfo method, TestStepAttribute attribute)
		{
			Console.WriteLine($"Executing Step: {attribute.StepName}, Expected Result: {attribute.ExpectedResult}");
			try
			{
				if (method.ReturnType == typeof(Task))
				{
					await (Task)method.Invoke(_testClassInstance, null);
				}
				else
				{
					method.Invoke(_testClassInstance, null);
				}
				Console.WriteLine($"[SUCCESS] Step '{attribute.StepName}' executed successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"[FAILURE] Step '{attribute.StepName}' failed: {ex.Message}");
			}
		}
	}
}
