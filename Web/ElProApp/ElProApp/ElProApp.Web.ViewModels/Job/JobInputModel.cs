namespace ElProApp.Web.ViewModels.Job
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Job;
    using static Common.EntityValidationErrorMessage.Job;
    using static Common.EntityValidationErrorMessage.Master;

    public class JobInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [MinLength(nameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(nameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [RegularExpression(@"\d{1,4}(\.\d{1,2})?", ErrorMessage = ErrorMassagePrice)]
        public decimal Price { get; set; }
    }
}
