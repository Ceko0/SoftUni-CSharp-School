namespace _03.PlantDiscovery
{
    class Plants
    {
        public Plants(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Rating = new List<double>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {Rating.Average():f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plants> plantsList = new List<Plants>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] plant = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = plant[0];
                int rarity = int.Parse(plant[1]);
                
                Plants existingPlant = plantsList.FirstOrDefault(x => x.Name == name);
                
                if (existingPlant == null)
                {
                    Plants newPlant = new Plants(name, rarity);
                    plantsList.Add(newPlant);
                    continue;
                }
                existingPlant.Rarity = rarity;
            }

            string income = "";
            while ((income = Console.ReadLine()) != "Exhibition")
            {
                string[] commands = income.Split(":");
                string[] plantInfo = commands[1]
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim(' '))
                    .ToArray();
                string command = commands[0];
                string name = plantInfo[0];
                switch (command)
                {
                    case "Rate":
                        double rating = double.Parse(plantInfo[1]);
                        Plants currentPlant = plantsList.FirstOrDefault(p => p.Name == name);
                        if (currentPlant == null)
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        currentPlant.Rating.Add(rating);
                        break;
                    case "Update":
                        int rarity = int.Parse(plantInfo[1]);
                        currentPlant = plantsList.FirstOrDefault(p => p.Name == name);
                        if (currentPlant == null)
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        currentPlant.Rarity = rarity;
                        break;
                    case "Reset":
                        currentPlant = plantsList.FirstOrDefault(p => p.Name == name);
                        if (currentPlant == null)
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        currentPlant.Rating.Clear();
                        currentPlant.Rating.Add(0);
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plants plant in plantsList)
            {
                Console.WriteLine(plant);
            }
        }
    }
}
