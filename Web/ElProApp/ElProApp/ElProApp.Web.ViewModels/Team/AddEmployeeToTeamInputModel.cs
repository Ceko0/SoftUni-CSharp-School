namespace ElProApp.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using Employee;

    using static ElProApp.Common.EntityValidationConstants.Employee;
    using static Common.EntityValidationErrorMessage.Master;
    using static Common.EntityValidationErrorMessage.Team;

    public class AddEmployeeToTeamInputModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string TeamName { get; set; }

        public IEnumerable<EmployeeCheckBoxItemInputModel> Employees { get; set; } =
            new HashSet<EmployeeCheckBoxItemInputModel>();
    }
}