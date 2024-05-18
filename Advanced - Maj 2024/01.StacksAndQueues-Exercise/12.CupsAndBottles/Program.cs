namespace _12.CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bottles = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int spaceLeft = 0;
            int wastedWater = 0;
            while(cups.Any() && bottles.Any())
            {
                int currentBottle = bottles.Pop();
                if(cups.Peek() < currentBottle)
                {
                    wastedWater += currentBottle - cups.Dequeue();
                }
                else
                {
                    spaceLeft = cups.Dequeue() - currentBottle;
                    while(spaceLeft > 0)
                    {
                        spaceLeft -= bottles.Pop();
                    }
                    wastedWater += spaceLeft * -1;
                }
            }
            if(!bottles.Any())
            {
                Console.Write("Cups: ");
                Console.WriteLine(string.Join(" ",cups));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else
            {
                Console.Write("Bottles: ");
                Console.WriteLine(string.Join(" ", bottles));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
