using System.ComponentModel.DataAnnotations;

using static ElProApp.Common.EntityValidationConstants.Team;

namespace ElProApp.Web.ViewModels.Employee
{
    public class EmployeeCheckBoxItemInputModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string EmployeeFirstName { get; set; }
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string EmployeeLastName { get; set; }

        public bool IsSelected { get; set; }

    }
}