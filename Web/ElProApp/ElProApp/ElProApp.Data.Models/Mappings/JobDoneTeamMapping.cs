namespace ElProApp.Data.Models.Mappings
{
    public class JobDoneTeamMapping
    {
        public Guid Id { get; set; }

        public Guid JobDoneId { get; set; }
        public JobDone JobDone { get; set; } = null!;

        public Guid TeamId { get; set; }
        public Team Team { get; set; } = null!;

    }
}
