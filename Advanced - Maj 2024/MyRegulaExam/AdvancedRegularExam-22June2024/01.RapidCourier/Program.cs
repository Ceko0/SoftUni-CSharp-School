namespace _01.RapidCourier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> packages = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> couriers = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int totalWeight = 0;

            while (packages.Count > 0 && couriers.Count > 0)
            {
                int packageWeight = packages.Pop();
                int courierCapacity = couriers.Dequeue();

                if (courierCapacity >= packageWeight)
                {
                    totalWeight += packageWeight;
                    courierCapacity -= packageWeight * 2;

                    if (courierCapacity > 0)
                    {
                        couriers.Enqueue(courierCapacity);
                    }
                }
                else
                {
                    totalWeight += courierCapacity;
                    packageWeight -= courierCapacity;
                    packages.Push(packageWeight);
                }
            }

            Console.WriteLine($"Total weight: {totalWeight} kg");

            if (packages.Count == 0 && couriers.Count == 0)
            {
                Console.WriteLine("Congratulations, all packages were delivered successfully by the couriers today.");
            }
            else if (packages.Count > 0)
            {
                Console.WriteLine($"Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
            }
            else if (couriers.Count > 0)
            {
                Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
            }
        }
    }
}
