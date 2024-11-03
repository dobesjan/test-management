namespace TestManagement.Reporting.Xunit.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
	public class TestStepAttribute : Attribute
	{
		public string StepName { get; }
		public string Identifier { get; }
		public string ExpectedResult { get; }
		public string MethodName { get; }

		public TestStepAttribute(string stepName, string identifier, string expectedResult, [System.Runtime.CompilerServices.CallerMemberName] string methodName = "")
		{
			StepName = stepName;
			Identifier = identifier;
			ExpectedResult = expectedResult;
			MethodName = methodName;
		}
	}
}
