namespace ElProApp.Data.Models
{
    using Mapping;


    public class Team
    {

        public Guid Id { get; set; } = new();
        public string Name { get; set; } = null!;

        public virtual ICollection<EmployeeTeamMapping> EmployeesMapping { get; set; } = new HashSet<EmployeeTeamMapping>();
        public virtual ICollection<BuildingTeamMapping> BuildingsMapping { get; set; } = new HashSet<BuildingTeamMapping>();
        public virtual ICollection<JobDoneTeamMapping> JobDoneMapping { get; set; } = new HashSet<JobDoneTeamMapping>();
    }
}