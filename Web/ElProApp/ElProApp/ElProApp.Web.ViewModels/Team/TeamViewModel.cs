using ElProApp.Web.ViewModels.Building;

namespace ElProApp.Web.ViewModels.Team
{
    using Employee;

    public class TeamViewModel
    {
        public Guid id { get; set; }
        public string Name { get; set; } = null!;

        public IEnumerable<EmployeeViewModel> EmployeeMapping = new HashSet<EmployeeViewModel>();

        public IEnumerable<BuildingViewModel> BuildingMapping = new HashSet<BuildingViewModel>();
    }
}