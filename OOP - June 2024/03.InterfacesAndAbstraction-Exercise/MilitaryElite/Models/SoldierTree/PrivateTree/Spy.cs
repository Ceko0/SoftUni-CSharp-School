using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece;
using MilitaryElite.Models.SoldierTree;
using System.Text;

namespace Models.SoldierTree.PrivateTree
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber)
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }
        public int CodeNumber { get; }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(base.ToString());
            sb.Append($"Code Number: {CodeNumber}");

            return sb.ToString();
        }

    }
}
