namespace ElProApp.Data.Models
{
    public class Team
    {

        public Guid Id { get; set; } = new();

        public string Name { get; set; } = null!;

        public ICollection<EmployeeTeamMapping> EmployeesMapping { get; set; }
    }
}