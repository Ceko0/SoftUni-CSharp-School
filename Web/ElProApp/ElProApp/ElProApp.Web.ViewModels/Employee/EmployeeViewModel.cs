namespace ElProApp.Web.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public decimal Wages { get; set; }

        public decimal MoneyToTake { get; set; }
    }
}
