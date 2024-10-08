
namespace ElProApp.Data.Models
{
    using Mapping;

    public class Employee
    {
        public Guid Id { get; set; } = new();
        public string LoginId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Wages { get; set; }
        public decimal MoneyToTake { get; set; }
        public Guid EmployeeTeamId { get; set; }

        public virtual ICollection<EmployeeTeamMapping> TeamsMapping { get; set; } = new HashSet<EmployeeTeamMapping>();

    }
}