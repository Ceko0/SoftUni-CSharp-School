namespace ElProApp.Web.ViewModels.Employee
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationConstants.Team;

    public class EmployeeCheckBoxItemInputModel
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string EmployeeFirstName { get; set; } = null!;
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string EmployeeLastName { get; set; } = null!;

        public bool IsSelected { get; set; }

    }
}
