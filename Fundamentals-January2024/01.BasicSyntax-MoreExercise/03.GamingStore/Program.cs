namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double spendedMoney =0;
            while (true)
            {
                double gamePrice = 0;
                string nameOfGame = Console.ReadLine();
                switch (nameOfGame)
                {
                    case "Game Time": Console.WriteLine($"Total spent: ${spendedMoney:f2}. Remaining: ${currentBalance:f2}"); return;
                    case "OutFall 4": gamePrice = 39.99; break;
                    case "CS: OG": gamePrice = 15.99; break;
                    case "Zplinter Zell": gamePrice = 19.99; break;
                    case "Honored 2": gamePrice = 59.99; break;
                    case "RoverWatch": gamePrice = 29.99; break;
                    case "RoverWatch Origins Edition": gamePrice = 39.99; break;
                    default: Console.WriteLine("Not Found"); continue;
                }
                if (currentBalance >= gamePrice) { currentBalance -= gamePrice; spendedMoney += gamePrice; Console.WriteLine($"Bought {nameOfGame}"); }
                else Console.WriteLine("Too Expensive");
                if (currentBalance <= 0) {Console.WriteLine($"Out of money!"); return;}
            }
        }
    }
}
