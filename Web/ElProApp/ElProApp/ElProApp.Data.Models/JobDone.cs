namespace ElProApp.Data.Models
{
    using Mapping;

    public class JobDone
    {
        public Guid Id { get; set; } = new();
        public Decimal Quantity { get; set; } 
        public int DaysForJobDone { get; set; }

        public virtual ICollection<JobDoneTeamMapping> TeamMapping { get; set; } = new List<JobDoneTeamMapping>();
        public virtual ICollection<JobDoneJobMapping> JobMapping { get; set; } = new HashSet<JobDoneJobMapping>();

    }
}
