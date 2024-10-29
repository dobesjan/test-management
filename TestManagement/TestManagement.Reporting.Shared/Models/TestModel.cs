using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Reporting.Shared.Models
{
	public class TestModel
	{
		public TestModel()
		{
			Assembly currentAssembly = MethodBase.GetCurrentMethod()?.DeclaringType?.Assembly;
			string name = currentAssembly?.GetName().Name;
			Console.WriteLine($"Current assembly name: {currentAssembly?.GetName().Name}");
		}
	}
}
