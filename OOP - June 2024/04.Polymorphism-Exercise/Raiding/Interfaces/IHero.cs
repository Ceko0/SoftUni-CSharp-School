
namespace Raiding.Interfaces
{
    public interface IHero
    {
        string Name { get; }
        int Power { get; }

        string CastAbility();
    }
}
