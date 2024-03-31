namespace _03.P_rates
{
    internal class Program
    {
        class City
        {
            public City(string name, int population, int gold)
            {
                Name = name;
                Population = population;
                Gold = gold;
            }

            public string Name { get; set; }
            public int Population { get; set; }
            public int Gold { get; set; }
            public override string ToString()
            {
                return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
            }
        }
        static void Main(string[] args)
        {
            List<City> allCity = new List<City>();
            string income = String.Empty;
            while ((income = Console.ReadLine()) != "Sail")
            {
                string[] commands = income
                    .Split("||", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = commands[0];
                int population = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);
                City city = new City(name, population, gold);
                City currentCity = allCity.FirstOrDefault(x => x.Name == name);
                if (currentCity != null)
                {
                    currentCity.Population += population;
                    currentCity.Gold += gold;
                }
                else allCity.Add(city);
            }

            while ((income = Console.ReadLine()) != "End")
            {
                string[] commands = income
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string toDo = commands[0];
                string name = commands[1];
                City currentCity = allCity.FirstOrDefault(x => x.Name == name);

                if (currentCity != null)
                {
                    switch (toDo)
                    {
                        case "Plunder":
                            int population = int.Parse(commands[2]);
                            int gold = int.Parse(commands[3]);
                            currentCity.Population -= population;
                            currentCity.Gold -= gold;
                            if (currentCity.Population > 0 && currentCity.Gold > 0) Console.WriteLine($"{name} plundered! {gold} gold stolen, {population} citizens killed.");
                            else
                            {
                                Console.WriteLine($"{name} plundered! {gold} gold stolen, {population} citizens killed.");
                                Console.WriteLine($"{name} has been wiped off the map!");
                                allCity.Remove(currentCity);
                            }
                            break;
                        case "Prosper":
                            gold = int.Parse(commands[2]);
                            if (gold > 0)
                            {
                                currentCity.Gold += gold;
                                Console.WriteLine($"{gold} gold added to the city treasury. {name} now has {currentCity.Gold} gold.");
                            }
                            else Console.WriteLine("Gold added cannot be a negative number!");
                            break;
                    }
                }
            }

            if (allCity.Count != 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {allCity.Count} wealthy settlements to go to:");
                Console.WriteLine(string.Join("\n" , allCity));
            }
            else Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
        }
    }
}
