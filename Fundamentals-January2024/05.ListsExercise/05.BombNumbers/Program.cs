namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> bombParameters = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            
            int minIndex = 0;
            int maxIndex = 0;
            int lastIndex = numbers.Count - 1;
            while (numbers.Contains(bombParameters[0]))
            {
                int bombIndex = numbers.FindIndex(x => x == bombParameters[0]);

                if (itIsInRange(lastIndex, bombIndex))
                {
                    minIndex = Math.Max(0, bombIndex - bombParameters[1]);
                    maxIndex = Math.Min(lastIndex, bombIndex + bombParameters[1]);
                    numbers.RemoveRange(minIndex, maxIndex - minIndex + 1);
                    
                }
            }
            Console.WriteLine(numbers.Sum());
        }

        static bool itIsInRange(int lastIndex, int position)
        {
            return (position >= 0 && position <= lastIndex);
        }
    }
}
/*
1 2 2 4 2 2 2 9
4 2

1 4 4 2 8 9 1
9 3
 */