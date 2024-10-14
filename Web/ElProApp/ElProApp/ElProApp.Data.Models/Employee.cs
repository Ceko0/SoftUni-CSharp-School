namespace ElProApp.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationErrorMessage.Employee;
    using static Common.EntityValidationErrorMessage.Master;
    using static Common.EntityValidationConstants.Employee;
    using Microsoft.EntityFrameworkCore;
    using ElProApp.Data.Models.Mappings;

    public class Employee
    {
        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Comment("Unique identifier for the employee.")]
        public Guid Id { get; set; } = new();

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        [Comment("The first name of the employee with a maximum of 20 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        [Comment("The last name of the employee with a maximum of 20 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Range(0.01, 9999.99, ErrorMessage = ErrorMassageWages)]
        [RegularExpression(@"^\d{1,4}(\.\d{1,2})?$", ErrorMessage = ErrorMassageWages)]
        [Comment("The wages of the employee with up to 4 digits before the decimal point and up to 2 digits after.")]
        public decimal Wages { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Range(0.01, double.MaxValue, ErrorMessage = ErrorMassageQuantityPozitive)]
        [Comment("The money the employee has to take, must be a positive value.")]
        public decimal MoneyToTake { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [Comment("Foreign key representing the team to which the employee belongs.")]
        public Guid TeamId { get; set; }

        public virtual ICollection<EmployeeTeamMapping> TeamsEmployeeBelongsTo { get; set; } = new HashSet<EmployeeTeamMapping>();
    }
}
