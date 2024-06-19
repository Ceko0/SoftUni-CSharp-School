namespace _01.WormsAndHoles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> worms = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> holes = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int matchesCount = 0;
            int wormsCount = worms.Count;            
            while (worms.Count > 0 && holes.Count > 0)
            {
                int wormPower = worms.Pop();
                int holesPower = holes.Dequeue();

                if (wormPower == holesPower)
                {
                    matchesCount++;
                    continue;
                }
                else
                
                {
                    if (wormPower - 3 > 0)
                        worms.Push(wormPower - 3);
                }
            }
            Console.WriteLine(matchesCount == 0 ? "There are no matches." : $"Matches: {matchesCount}");
            if (worms.Count == 0 && wormsCount == matchesCount )
                Console.WriteLine("Every worm found a suitable hole!");            
            else
                Console.WriteLine(worms.Count == 0 ? "Worms left: none" : $"Worms left: {string.Join(", ", worms)}");
            Console.WriteLine(holes.Count == 0 ? "Holes left: none" : $"Holes left: {string.Join(", ", holes)}");
        }
    }
}