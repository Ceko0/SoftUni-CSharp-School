namespace ElProApp.Web.ViewModels.Team
{
    using Employee;
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Team;
    using static Common.EntityValidationErrorMessage.Team;
    using static Common.EntityValidationErrorMessage.Master;
    
    public class TeamInputModel
    {
        public Guid Id {get; set; }

        [Required(ErrorMessage = ErrorMassageFieldForNameIsRequired)]
        [MinLength(NameMinLength, ErrorMessage = ErrorMassageNameMinLength)]
        [MaxLength(NameMaxLength, ErrorMessage = ErrorMassageNameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<EmployeeCheckBoxItemInputModel> EmployeeList { get; set; } = new HashSet<EmployeeCheckBoxItemInputModel>();
    }
}
