using MilitaryElite.Enums;
using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece.SpecialisedSoldierInterfece;
using MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree;
using Models.SoldierTree.PrivateTree;
using System.Text;

namespace MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int id, string firstName, string lastName, decimal salary, SoldierCorps corps) 
            : base(id, firstName, lastName, salary , corps)
        {
            repiars = new();            
        }
        public List<Repair> repiars { get; }

        public IReadOnlyCollection<Repair> Repairs => repiars.AsReadOnly();
        public void AddRepair(Repair repair)
        {
            repiars.Add(repair);
        }
        public override string ToString()
        {
            StringBuilder sb = new ();
            sb.AppendLine(base.ToString());
            sb.Append("Repairs:");

            foreach (Repair repair in this.Repairs)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(repair);
            }

            return sb.ToString();
        }
    }
}
