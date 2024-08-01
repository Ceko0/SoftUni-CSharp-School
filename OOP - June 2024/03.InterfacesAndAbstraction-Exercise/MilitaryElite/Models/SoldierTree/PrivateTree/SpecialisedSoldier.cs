using Interfaces.SoldierInterfece.PrivateInterfece;
using MilitaryElite.Enums;
using MilitaryElite.Models.SoldierTree.PrivateTree;
using System.Text;

namespace Models.SoldierTree.PrivateTree
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary,SoldierCorps corps)
            : base(id, firstName, lastName, salary)
        {
            Corps = corps;            
        }

        public SoldierCorps Corps { get; }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(base.ToString());
            sb.Append($"Corps: {this.Corps}");

            return sb.ToString();
        }

        public IReadOnlyCollection<Private> Privates { get; }
    }
}
