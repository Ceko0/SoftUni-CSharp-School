namespace ElProApp.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;
    using ElProApp.Web.ViewModels.Employee;

    using static ElProApp.Common.EntityValidationConstants.Team;
    using static ElProApp.Common.EntityValidationErrorMessage.Team;
    using static ElProApp.Common.EntityValidationErrorMessage.Master;

    public class AddEmployeeToTeamInputModel
    {
        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = ErrorMassageFieldIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string TeamName { get; set; } = null!;

        public IEnumerable<EmployeeCheckBoxItemInputModel> Employees { get; set; } = new HashSet<EmployeeCheckBoxItemInputModel>();
    }
}
