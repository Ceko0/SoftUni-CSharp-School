using Interfaces.SoldierInterfece;

namespace MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
