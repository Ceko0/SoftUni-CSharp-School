namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bullerPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());
            Stack<int> bullets = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> locks = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int intelligence = int.Parse(Console.ReadLine());
            int currentGunBarrel = gunBarrel;
            while(bullets.Any() && locks.Any())
            {
                intelligence -= bullerPrice;
                currentGunBarrel --;
                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (currentGunBarrel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    currentGunBarrel = gunBarrel;
                }
            }
            if(locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");                
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence}");                
            }
        }
    }
}
