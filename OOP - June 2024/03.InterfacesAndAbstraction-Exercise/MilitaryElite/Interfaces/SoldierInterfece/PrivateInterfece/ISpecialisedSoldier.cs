using MilitaryElite.Enums;
using MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfeceInterfece;

namespace Interfaces.SoldierInterfece.PrivateInterfeceInterefece
{
    public interface ISpecialisedSoldier : ILieutenantGeneral
    {
        SoldierCorps Corps { get; }
    }
}