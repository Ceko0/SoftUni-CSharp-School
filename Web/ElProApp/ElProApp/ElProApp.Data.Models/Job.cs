namespace ElProApp.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Job;
    using static Common.EntityValidationErrorMessage.Job;
    using static Common.EntityValidationErrorMessage.Master;

    public class Job
    {
        public Guid Id { get; set; } = new();

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MaxLength(nameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        [Comment("The name of the job with a maximum of 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Range(0.01, 9999.99, ErrorMessage = ErrorMassagePrice)]
        [RegularExpression(@"^\d{1,4}(\.\d{1,2})?$", ErrorMessage = ErrorMassagePrice)]
        [Comment("The price of the job with up to 4 digits before the decimal point and up to 2 digits after.")]
        public decimal Price { get; set; }

        public virtual ICollection<JobDone> JobsDone { get; set; } = new HashSet<JobDone>();
    }
}
