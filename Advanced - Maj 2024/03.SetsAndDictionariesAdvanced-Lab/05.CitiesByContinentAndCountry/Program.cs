using System.Text;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continents = new();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }
                continents[continent][country].Add(city);
            }
            StringBuilder sB = new StringBuilder();

            foreach ((string continent , Dictionary<string, List<string>> contries) in continents)
            {
                sB.Append($"{continent}: {Environment.NewLine}");
                foreach ((string country , List<string> cities) in contries)
                {
                    sB.Append($"  {country} -> ");
                    sB.Append(string.Join(", ", cities));
                    sB.ToString().TrimEnd(',');
                    sB.AppendLine();
                }               
            }
            Console.WriteLine(sB);
        }
    }
}
