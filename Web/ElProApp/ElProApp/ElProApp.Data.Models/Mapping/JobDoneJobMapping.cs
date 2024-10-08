namespace ElProApp.Data.Models.Mapping
{
    public class JobDoneJobMapping
    {
        public string Id { get; set; } = null!;
        public Guid JobDoneId { get; set; }
        public JobDone JobDone { get; set; } = null!;
        public Guid JobId { get; set; }
        public Job Job { get; set; } = null!;

    }
}
