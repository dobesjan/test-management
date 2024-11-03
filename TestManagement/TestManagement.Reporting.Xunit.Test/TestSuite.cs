using TestManagement.Reporting.Shared.Attributes;
using TestManagement.Reporting.Xunit.Attributes;
using TestManagement.Reporting.Xunit.Fixtures;
using TestManagement.Reporting.Shared.Core;
using TestManagement.Reporting.Shared.Models;
using Xunit.Abstractions;

[assembly: Xunit.TestFramework("TestManagement.Reporting.Shared.Core.TestManagementTestFramework", "TestManagement.Reporting.Shared")]
namespace TestManagement.Reporting.Xunit.Test
{
	//[TestSuiteExecutor]
	[TestSuite("TestSuite", "1", 1, "Testing suite")]
	public class TestSuite
	{
		private readonly ITestOutputHelper _output;

		public TestSuite(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public async void Test()
		{
			await ThrowException();
		}

		[Fact]
		public async void Test_Pass()
		{
			await OpenLoginPage();
		}

		//[Fact]
		[TestCase("Test 1", "1", "Testing test")]
		//[TestCaseExecutor]
		public async Task Test1()
		{
			_output.WriteLine("This is a test log message.");
			await OpenLoginPage();
			await EnterUsername();
			await EnterPassword();
		}

		[TestStep("Throw exception", "999", "Just throws exception.")]
		public async Task ThrowException()
		{
			throw new Exception();
		}

		[TestStep("Open Login Page", "100", "Login page should be displayed")]
		public async Task OpenLoginPage()
		{
			// Selenium code to open the login page
			await Task.CompletedTask;
		}

		[TestStep("Enter Username", "101", "Username should be entered correctly")]
		public async Task EnterUsername()
		{
			// Selenium code to enter username
			await Task.CompletedTask;
		}

		[TestStep("Enter Password", "102", "Password should be entered correctly")]
		public async Task EnterPassword()
		{
			// Selenium code to enter password
			await Task.CompletedTask;
		}
	}
}