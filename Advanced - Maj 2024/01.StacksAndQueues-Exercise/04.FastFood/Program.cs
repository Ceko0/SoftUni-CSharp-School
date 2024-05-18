namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );
            Console.WriteLine(orders.Max());
            while (orders.Any())
            {
                int currentOrder = orders.Peek();
                if (foodQuantity >= currentOrder)
                {
                    foodQuantity -= orders.Dequeue();
                }
                else
                {
                    Console.Write("Orders left: ");
                    Console.WriteLine(string.Join(" ",orders));
                    return;
                }
            }
            Console.WriteLine("Orders complete");
        }
    }
}
