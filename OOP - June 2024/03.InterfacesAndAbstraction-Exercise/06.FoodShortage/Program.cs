using System.Diagnostics.Metrics;

namespace FoodShortage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> peopleList = new();
            int peopleCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < peopleCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    string name = input[0];
                    Citizen citizen = new(name, int.Parse(input[1]), input[2], input[3]);
                    peopleList.Add(name, citizen);
                }
                if (input.Length == 3)
                {
                    string name = input[0];
                    Rebel rebel = new(name, int.Parse(input[1]), input[2]);
                    peopleList.Add(name, rebel);
                }
            }
            string buyer = string.Empty;
            while ((buyer = Console.ReadLine()) != "End")
            {
                var person = peopleList.FirstOrDefault(x => x.Key == buyer).Value;
                if (person != null)
                {
                    person.BuyFood();
                }
            }

            Console.WriteLine($"{peopleList.Sum(x => x.Value.Food)}");
        }
    }
}
