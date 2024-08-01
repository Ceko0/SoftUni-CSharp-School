using MilitaryElite.Enums;
using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece.SpecialisedSoldierInterfece.SetForSpecialistInterfece;

namespace MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionState state)
        {
            if (string.IsNullOrWhiteSpace(codeName)) throw new ArgumentException(nameof(codeName));           
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; }
        public MissionState State { get; }
        public override string ToString() => $"Code Name: {this.CodeName} State: {this.State}";
    }
}
