namespace ElProApp.Data.Models.Mapping
{
    public class EmployeeTeamMapping
    {
        public string id { get; set; } = null!;
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;
    }
}