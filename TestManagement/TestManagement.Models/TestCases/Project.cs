﻿namespace TestManagement.Models.TestCases
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

		public List<ProjectHasTestLabel>? ProjectHasTestLabels { get; set; }
	}
}
