
namespace ElProApp.Data.Models
{
    using Mapping;

    public class Building
    {
        public Guid Id { get; set; } = new();
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;

        public virtual ICollection<BuildingTeamMapping> TeamMappings { get; set; } = new HashSet<BuildingTeamMapping>();
    }
}
