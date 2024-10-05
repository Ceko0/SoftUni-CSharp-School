using System.ComponentModel.DataAnnotations;
using ElProApp.Web.ViewModels.Employee;

using static ElProApp.Common.EntityValidationConstants.employee;

namespace ElProApp.Web.ViewModels.Team
{
    public class AddEmployeeToTeamInputModel
    {
        [Required]
        public  Guid Id { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string TeamName { get; set; }

        public IEnumerable<EmployeeCheckBoxItemInputModel> Employees { get; set; } =
            new HashSet<EmployeeCheckBoxItemInputModel>();
    }
}