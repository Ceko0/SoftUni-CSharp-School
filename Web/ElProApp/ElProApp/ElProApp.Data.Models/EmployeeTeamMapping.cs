namespace ElProApp.Data.Models
{
    public class EmployeeTeamMapping
    {
        public string id { get; set; }
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Guid EmployeeTeamId { get; set; }

        public Team Team { get; set; }
    }
}