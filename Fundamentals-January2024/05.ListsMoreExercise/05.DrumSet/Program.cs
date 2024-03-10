namespace _05.DrumSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            List<int> startDrumSet = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> drumSet = startDrumSet.ToList();
            string income = "";
            while ((income = Console.ReadLine()) != "Hit it again, Gabsy!")
            {
                int currentStr = int.Parse(income);
                for (int i = 0; i < drumSet.Count; i++)
                {
                    drumSet[i] -= currentStr;

                    if (drumSet[i] <= 0)
                    {
                        if (money < startDrumSet[i] * 3)
                        {
                            drumSet.RemoveAt(i);
                            startDrumSet.RemoveAt(i);
                            i--;
                            continue;
                        }
                        drumSet[i] = startDrumSet[i];
                        money -= startDrumSet[i]*3;
                    }
                }
            }
            Console.WriteLine(string.Join(" ", drumSet));
            Console.WriteLine($"Gabsy has {money:f2}lv.");
        }
    }
}