namespace ElProApp.Data.Models.Mapping
{
    public class BuildingTeamMapping
    {
        public string Id { get; set; } = null!;
        public Guid BuildingId { get; set; }
        public Building Building { get; set; } = null!;
        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;
    }
}
