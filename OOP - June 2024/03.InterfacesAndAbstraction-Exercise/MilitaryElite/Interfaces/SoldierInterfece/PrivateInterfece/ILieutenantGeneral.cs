using Interfaces.SoldierInterfece.PrivateInterfece;

namespace MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}