﻿namespace ElProApp.Data.Models
{

    public class Employee
    {
        public Guid Id { get; set; } = new();

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public decimal Wages { get; set; }

        public decimal MoneyToTake { get; set; }
        
        public Guid EmployeeTeamId { get; set; }

        public ICollection<EmployeeTeamMapping> EmployeeTeamsMapping { get; set; }

    }
}