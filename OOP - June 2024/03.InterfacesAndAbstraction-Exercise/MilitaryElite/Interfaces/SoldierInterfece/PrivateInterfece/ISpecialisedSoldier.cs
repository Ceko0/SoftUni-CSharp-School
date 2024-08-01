using MilitaryElite.Enums;
using Interfaces.SoldierInterfece.PrivateInterfece;

namespace Interfaces.SoldierInterfece.PrivateInterfece
{
    public interface ISpecialisedSoldier : IPrivate
    {
        SoldierCorps Corps { get; }
    }
}