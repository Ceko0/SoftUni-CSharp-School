using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    internal class Program
    {
        class Planet
        {
            public Planet(string name, int population, string type, int soldier)
            {
                Name = name;
                Population = population;
                Type = type;
                Soldier = soldier;
            }

            public string Name { get; set; }
            public int Population { get; set; }
            public string Type { get; set; }
            public int Soldier { get; set; }

        }
        static void Main(string[] args)
        {
            List<Planet> planetsList = new List<Planet>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string msg = Console.ReadLine();
                string patternDecoder = @"[starSTAR]";

                MatchCollection mathces = Regex.Matches(msg, patternDecoder);
                int code = mathces.Count;
                string encryptedMSG = string.Empty;
                foreach (char symbol in msg)
                {
                    int newSymbol = (char)(symbol - code);
                    encryptedMSG += (char)newSymbol;
                }

                string pattern = @"[^\@\-\!\:\>]*(\@(?<name>[A-Za-z]+))[^\@\-\!\:\>]*(\:(?<population>[\d]+))[^\@\-\!\:\>]*(\!(?<type>[A|D])\!)[^\@\-\!\:\>]*(\-\>(?<soldier>[\d]+))[^\@\-\!\:\>]*";

                mathces = Regex.Matches(encryptedMSG, pattern);
                
                foreach (Match match in mathces)
                {
                    Planet planet = new Planet(match.Groups["name"].Value, int.Parse(match.Groups["population"].Value), match.Groups["type"].Value, int.Parse(match.Groups["soldier"].Value));
                    planetsList.Add(planet);
                }
            }
            var attackedPlanet = planetsList
                .Where(p => p.Type == "A")
                .ToList();
            Console.WriteLine($"Attacked planets: {attackedPlanet.Count}");
            foreach (var planet in attackedPlanet.OrderBy(x => x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
            var destroyedPlanet = planetsList
                .Where(p => p.Type == "D")
                .ToList();
            Console.WriteLine($"Destroyed planets: {destroyedPlanet.Count}");
            foreach (var planet in destroyedPlanet.OrderBy(x =>x.Name))
            {
                Console.WriteLine($"-> {planet.Name}");
            }
        }
    }
}
