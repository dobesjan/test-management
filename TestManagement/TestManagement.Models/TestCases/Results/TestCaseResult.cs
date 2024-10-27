using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
