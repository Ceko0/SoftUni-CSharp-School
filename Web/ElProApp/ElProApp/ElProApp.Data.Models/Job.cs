
namespace ElProApp.Data.Models
{
    using Mapping;

    public class Job
    {
        public Guid Id { get; set; } = new();
        public string Name { get; set; } = null!;
        public decimal Price {get; set; }

        public virtual ICollection<JobDoneJobMapping> JobDoneMapping { get; set; } = new HashSet<JobDoneJobMapping>();
    }
}
