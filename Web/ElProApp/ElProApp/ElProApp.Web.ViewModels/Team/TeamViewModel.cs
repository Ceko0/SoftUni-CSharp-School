using ElProApp.Web.ViewModels.Employee;

namespace ElProApp.Web.ViewModels.Team
{
    public class TeamViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<EmployeeViewModel> EmployeeMapping = new HashSet<EmployeeViewModel>();
    }
}