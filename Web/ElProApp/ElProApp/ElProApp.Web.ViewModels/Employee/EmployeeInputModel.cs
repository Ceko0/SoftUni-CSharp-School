using ElProApp.Common;

namespace ElProApp.Web.ViewModels.Employee
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Employee;
    using static Common.EntityValidationErrorMessage.Employee;
    using static EntityValidationErrorMessage.Master;
    public class EmployeeInputModel
    {
        public Guid Id { get; set; }

        public string LoginId { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [RegularExpression(@"\d{1,4}(\.\d{1,2})?", ErrorMessage = ErrorMassageWages)]
        public decimal Wages { get; set; }

        public decimal MoneyToTake { get; set; }

    }
}