namespace _02.CarRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] carsTime = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int finish = carsTime.Length / 2;
            double totalLeft = 0;
            double totalRight = 0;

            for (int i = 0; i < finish; i++)
            {

                if (carsTime[i] == 0)
                {
                    totalLeft *= 0.8;
                }

                totalLeft += carsTime[i];
            }
            for (int i = carsTime.Length - 1; i > finish; i--)
            {
                if (carsTime[i] == 0)
                {
                    totalRight *= 0.8;
                }

                totalRight += carsTime[i];
            }

            if (totalLeft < totalRight)
            {
                Console.WriteLine($"The winner is left with total time: {totalLeft}");
                return;
            }
            Console.WriteLine($"The winner is right with total time: {totalRight}");
        }
    }
}
