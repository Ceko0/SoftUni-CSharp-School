
namespace ElProApp.Data.Models
{
    using ElProApp.Data.Models.Mappings;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationErrorMessage.JobDobe;
    using static Common.EntityValidationErrorMessage.Master;

    public class JobDone
    {
        [Required]
        [Comment("Unique identifier for the job done record")]
        public Guid Id { get; set; } = new();

        [Required]
        [Comment("Foreign key for the job being done")]
        public Guid JobId { get; set; }

        [Required]
        [Comment("The job associated with this record. Represents the job that has been completed.")]
        public Job Job { get; set; } = null!;
        
        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Range(0.01, double.MaxValue, ErrorMessage = ErrorMassagePozitive)]
        [RegularExpression(@"^\d{1,6}(\.\d{1,2})?$", ErrorMessage = ErrorMassageQuantity)]
        [Comment("Quantity of work completed")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Range(1, 30, ErrorMessage =ErrorMassageDaysForJob)]
        [Comment("Number of days spent completing the job")]
        public int DaysForJob { get; set; }

        public virtual ICollection<JobDoneTeamMapping> TeamsDoTheJob { get; set; } = new HashSet<JobDoneTeamMapping>();

    }
}
