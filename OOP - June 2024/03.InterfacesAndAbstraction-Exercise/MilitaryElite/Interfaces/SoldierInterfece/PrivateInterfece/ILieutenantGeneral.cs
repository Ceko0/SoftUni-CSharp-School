using Interfaces.SoldierInterfece.PrivateInterfece;
using MilitaryElite.Models.SoldierTree.PrivateTree;

namespace MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfeceInterfece
{
    public interface ILieutenantGeneral : ISpecialisedSoldier
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
    
}
