using Interfaces.SoldierInterfece.PrivateInterfece;

namespace MilitaryElite.Models.SoldierTree.PrivateTree
{
    public class Private : Soldier , IPrivate
    {
        public Private(int id, string firstName, string lastName, Decimal salary)
            : base(id, firstName, lastName)
        {
            if (salary < 0) throw new ArgumentException("Salary can`t be negative");
            Salary = salary;
        }
        public Decimal Salary { get; }
        public override string ToString() => $"{base.ToString()} Salary: {this.Salary:f2}";
    }
}
