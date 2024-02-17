namespace _03.HeartDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@" , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            string income = "";
            int landingHouse = 0;
            while ((income = Console.ReadLine()) != "Love!")
            {
                List<string> commands = income
                    .Split()
                    .ToList();

                int jumpLength = int.Parse(commands[1]);
                landingHouse += jumpLength;
                if (landingHouse >= neighborhood.Count)
                {
                    landingHouse = 0;
                }

                if (neighborhood[landingHouse] > 0)
                {
                    neighborhood[landingHouse] -= 2;
                    if (neighborhood[landingHouse] <= 0 )
                    {
                        Console.WriteLine($"Place {landingHouse} has Valentine's day.");
                    }
                }
                else
                {
                    Console.WriteLine($"Place {landingHouse} already had Valentine's day.");
                }
            }
            Console.WriteLine($"Cupid's last position was {landingHouse}.");
           
            int houseCounter = 0;
            foreach (var item in neighborhood)
            {
                if (item != 0)
                {
                    houseCounter++;
                }
            }
            if (houseCounter != 0) 
            {
                Console.WriteLine($"Cupid has failed {houseCounter} places.");
            }
            else 
            { 
                Console.WriteLine("Mission was successful.");
            }
        }
    }
}
