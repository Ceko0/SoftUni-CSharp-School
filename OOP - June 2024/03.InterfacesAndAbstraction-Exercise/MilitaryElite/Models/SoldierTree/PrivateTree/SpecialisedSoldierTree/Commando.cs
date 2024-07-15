using MilitaryElite.Enums;
using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece.SpecialisedSoldierInterfece;
using MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree;
using Models.SoldierTree.PrivateTree;
using System.Text;

namespace MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int id, string firstName, string lastName, decimal salary, SoldierCorps corps) 
            : base(id, firstName, lastName, salary, corps)
        {
            missions = new();
        }
        public List<Mission> missions { get; }

        public IReadOnlyCollection<Mission> Missions => missions.AsReadOnly();
        public void AddMission(Mission mission)
        {
            missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(base.ToString());
            sb.Append("Missions:");

            foreach (Mission mission in this.Missions)
            {
                sb.AppendLine();
                sb.Append("  ");
                sb.Append(mission);
            }

            return sb.ToString(); ;
        }
    }
}
