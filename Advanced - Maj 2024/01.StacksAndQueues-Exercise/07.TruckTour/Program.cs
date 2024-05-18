namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumps = int.Parse(Console.ReadLine());
            Queue<(int, int)> pumpsinfo = new();

            for (int i = 0; i < pumps; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                int distance = input[0];
                int petrol = input[1];
                pumpsinfo.Enqueue((distance, petrol));
            }
            int position = 0;
            int gasTank = 0;
            int endCounter = 0;
            while (true)
            {

                foreach (var (petrol, distance) in pumpsinfo)
                {
                    if (gasTank + petrol >= distance)
                    {
                        gasTank += petrol - distance;
                        endCounter++;
                    }
                    else
                    {
                        pumpsinfo.Enqueue(pumpsinfo.Dequeue());
                        position++;
                        endCounter = 0;
                        gasTank = 0;
                        break;
                    }
                    if (endCounter == pumps)
                    {
                        Console.WriteLine(position);
                        return;
                    }
                }
            }
        }
    }
}
