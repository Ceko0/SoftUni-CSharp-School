namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            int capacityOfTank = 255;
            int waterInTank = 0;
            for (int i = 0; i < counter; i++)
            {
                int quantitiesOfWater = int.Parse(Console.ReadLine());
                if (capacityOfTank >= quantitiesOfWater)
                {
                    capacityOfTank -= quantitiesOfWater;
                    waterInTank += quantitiesOfWater;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

            }
            Console.WriteLine(waterInTank);
        }
    }
}
