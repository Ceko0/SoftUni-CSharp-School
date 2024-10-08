namespace ElProApp.Data.Models.Mapping
{
    public class JobDoneTeamMapping
    {
        public string Id { get; set; } = null!;
        public Guid JobDoneId { get; set; }
        public JobDone JobDone { get; set; } = null!;
        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;

    }
}
