using System.Reflection.Metadata;

namespace _09.PredicateParty_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> comingPeople = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Func<List<string>, string, string, List<string>> remove
                    = (comingPeople, operation, value) =>
                    {
                        return operation == "StartsWith"
                        ? comingPeople.Where(p => p.StartsWith(value)).ToList()
                        : operation == "EndsWith"
                        ? comingPeople.Where(p => p.EndsWith(value)).ToList()
                        : comingPeople.Where(p => p.Length == int.Parse(value)).ToList();
                    };

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] command = input
                    .Split();
                string mainOperation = command[0];
                string operation = command[1];
                string value = command[2];

                List<string> targetPeople = remove(comingPeople, operation, value);

                if (mainOperation == "Remove")
                {
                    comingPeople = comingPeople.Where(x => !targetPeople.Contains(x)).ToList();
                }
                else if (mainOperation == "Double")
                {
                    foreach (string name in targetPeople)
                    {
                        int index = comingPeople.IndexOf(name);
                        comingPeople.Insert(index, name);
                    }
                }
            }

            if (comingPeople.Count > 0)
            {
                Console.WriteLine(string.Join(", ", comingPeople) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
