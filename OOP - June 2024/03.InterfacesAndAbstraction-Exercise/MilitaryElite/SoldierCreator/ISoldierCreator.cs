using Interfaces.SoldierInterfece;
using MilitaryElite.Enums;
using MilitaryElite.Models.SoldierTree;
using MilitaryElite.Models.SoldierTree.PrivateTree;
using MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree;
using MilitaryElite.Models.SoldierTree.PrivateTree.SpecialisedSoldierTree.SetForSpecialistTree;

namespace MilitaryElite.SoldierCreator
{
    public interface ISoldierCreator
    {
        public ISoldier CreateSoldier(string input, Dictionary<int ,ISoldier> privates)
        {
            string[] soldierInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string type = soldierInfo[0];
            switch (type)
            {
                case "Private":
                   Private privateSoldier = new(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]));
                    return privateSoldier;
                case "LieutenantGeneral":
                    LieutenantGeneral lieutenantGeneral =  new(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]));
                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        int privateId = int.Parse(soldierInfo[i]);
                        if (privates.TryGetValue(privateId, out var currentPrivate)) lieutenantGeneral.AddPrivate((Private)currentPrivate);
                    }
                    return lieutenantGeneral;
                case "Engineer":

                    if (!Enum.TryParse(soldierInfo[5], out SoldierCorps corps)) return null;
                    Engineer engineer = new(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]),corps);

                    for (int i = 6; i < soldierInfo.Length; i += 2)
                    {
                        Repair repair = new Repair(soldierInfo[i], int.Parse(soldierInfo[i + 1]));
                        engineer.AddRepair(repair);
                    }
                    return engineer;
                case "Commando":

                    if (!Enum.TryParse(soldierInfo[5], out  corps)) return null;
                    Commando commando = new(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], decimal.Parse(soldierInfo[4]), corps);

                    for (var i = 6; i < soldierInfo.Length; i += 2)
                    {
                        if (!Enum.TryParse(soldierInfo[i + 1], out MissionState state)) continue;

                        var mission = new Mission(soldierInfo[i], state);
                        commando.AddMission(mission);
                    }
                    return commando;
                case "Spy":
                    Spy spy = new(int.Parse(soldierInfo[1]), soldierInfo[2], soldierInfo[3], int.Parse(soldierInfo[4]));
                    return spy;
                default:
                     throw new ArgumentException("Invalid Soldier!");
            }
        }
    }
}
