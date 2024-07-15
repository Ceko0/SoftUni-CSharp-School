using Interfaces.SoldierInterfece;

namespace Interfaces.SoldierInterfece.PrivateInterfece
{
    public interface ISpecialisedSoldier : ISoldier
    {
        decimal Salary { get; }
    }
}
