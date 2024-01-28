namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] trainWagons = new int[int.Parse(Console.ReadLine())];
            int totalPeople = 0;
            for (int i = 0; i < trainWagons.Length; i++)
            {
                int incomePeople = int.Parse(Console.ReadLine());
                trainWagons[i] += incomePeople;
                totalPeople += incomePeople;
            }

            Console.WriteLine(string.Join(" ", trainWagons));
            Console.WriteLine(totalPeople);
        }
    }
}
