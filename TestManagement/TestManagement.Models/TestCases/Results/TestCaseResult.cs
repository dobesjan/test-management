using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestManagement.Results.Trx.Models;

namespace TestManagement.Models.TestCases.Results
{
    public enum TestRunStatus
    {
        SUCCESS = 1,
        FAILURE = 2,
        SKIPPED = 3
    }

    public class TestCaseResult : Entity
    {
		public int TestCaseId { get; set; }

        [ForeignKey(nameof(TestCaseId))]
        public TestCase TestCase { get; set; }

        public int TestRunStatusId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? ResultErrorInfoId { get; set; }

        [ForeignKey(nameof(ResultErrorInfoId))]
        public ResultErrorInfo? ResultErrorInfo { get; set; }

        public static TestCaseResult FromUnitTestResult(int testCaseId, UnitTestResult unitTestResult)
		{
			int testRunStatusId = GetTestResultFromUnitTestResult(unitTestResult);

			var testCaseResult = new TestCaseResult
			{
				StartTime = unitTestResult.StartTime,
				EndTime = unitTestResult.EndTime,
				TestRunStatusId = testRunStatusId,
				TestCaseId = testCaseId
			};

			if (unitTestResult.Output != null && unitTestResult.Output.ErrorInfo != null)
			{
				ResultErrorInfo resultErrorInfo = new ResultErrorInfo
				{
					Message = unitTestResult.Output.ErrorInfo.Message,
					StackTrace = unitTestResult.Output.ErrorInfo.StackTrace
				};

				testCaseResult.ResultErrorInfo = resultErrorInfo;
			}

			return testCaseResult;
		}

		private static int GetTestResultFromUnitTestResult(UnitTestResult unitTestResult)
		{
			int testRunStatusId = (int)TestRunStatus.SKIPPED;

			if (unitTestResult.Outcome == "Passed")
			{
				testRunStatusId = (int)TestRunStatus.SUCCESS;
			}
			else if (unitTestResult.Outcome == "Failed")
			{
				testRunStatusId = (int)TestRunStatus.FAILURE;
			}

			return testRunStatusId;
		}
	}
}
