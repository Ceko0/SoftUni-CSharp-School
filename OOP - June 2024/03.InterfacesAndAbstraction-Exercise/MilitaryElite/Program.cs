using Interfaces.SoldierInterfece;
using MilitaryElite.Models.SoldierTree;
using MilitaryElite.Models.SoldierTree.PrivateTree;
using MilitaryElite.SoldierCreator;

namespace MilitaryElite;

public class Program
{
    static void Main()
    {
        Dictionary<int ,ISoldier> soldiers = new();
        List<ISoldier> orderedSoldier = new();

        string input = string.Empty;
        while((input = Console.ReadLine()) != "End")
        {
            try
            {
                ISoldierCreator soldier = new EmptySoldier();
                ISoldier newSoldier =  soldier.CreateSoldier(input, soldiers);
                soldiers.Add(newSoldier.Id, newSoldier);
                orderedSoldier.Add(newSoldier);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        foreach (var soldier in orderedSoldier) Console.WriteLine(soldier);
    }
}
