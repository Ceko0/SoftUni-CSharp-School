namespace ElProApp.Data.Models.Mappings
{
    public class BuildingTeamMapping
    {
        public Guid Id { get; set; }

        public Guid BuildingId { get; set; }
        public Building Building { get; set; } = null!;

        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;
    }
}
