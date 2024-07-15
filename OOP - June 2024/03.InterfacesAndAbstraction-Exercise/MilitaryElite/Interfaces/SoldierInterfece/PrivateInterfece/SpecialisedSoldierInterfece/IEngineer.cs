using Interfaces.SoldierInterfece.PrivateInterfece;
using MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree;

namespace MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece.SpecialisedSoldierInterfece
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<Repair>  Repairs { get; }
    }
}
