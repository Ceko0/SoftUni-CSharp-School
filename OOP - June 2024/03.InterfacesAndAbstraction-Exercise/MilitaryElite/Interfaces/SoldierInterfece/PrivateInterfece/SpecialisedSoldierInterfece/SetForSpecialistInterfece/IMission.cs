using MilitaryElite.Enums;

namespace MilitaryElite.Interfaces.SoldierInterfece.PrivateInterfece.SpecialisedSoldierInterfece.SetForSpecialistInterfece
{
    public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }
    }
}
