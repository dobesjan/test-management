﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Models.TestCases
{
	public class Environment : Entity
	{
		public string Name { get; set; }

		public int ProjectId { get; set; }

		[ForeignKey(nameof(ProjectId))]
		public Project Project { get; set; }
	}
}
