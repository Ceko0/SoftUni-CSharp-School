namespace ElProApp.Web.ViewModels.Employee
{
    using Team;

    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string LoginId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public decimal Wages { get; set; }

        public decimal MoneyToTake { get; set; }

        public IEnumerable<TeamViewModel> TeamMapping { get; set; } = new HashSet<TeamViewModel>();
    }
}