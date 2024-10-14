namespace ElProApp.Data.Models.Mappings
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeTeamMapping
    {
        [Required]
        [Comment("Unique identifier for the mapping between Employee and Team.")]
        public Guid Id { get; set; } = new();

        [Required]
        [Comment("Foreign key for the employee.")]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; } = null!;

        [Required]
        [Comment("Foreign key for the team.")]
        public Guid TeamId { get; set; }

        public Team Team { get; set; } = null!;


    }
}
