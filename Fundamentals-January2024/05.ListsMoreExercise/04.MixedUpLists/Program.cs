namespace _04.MixedUpLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();
            List<int> condition = new List<int>();
            
            if (firstNumbers.Count < secondNumbers.Count)
            {
                condition.Add(secondNumbers[secondNumbers.Count-1]);
                secondNumbers.RemoveAt(secondNumbers.Count-1);
                condition.Add(secondNumbers[secondNumbers.Count-1]);
                secondNumbers.RemoveAt(secondNumbers.Count-1);
            }
            else
            {
                condition.Add(firstNumbers[firstNumbers.Count - 1]);
                firstNumbers.RemoveAt(firstNumbers.Count - 1);
                condition.Add(firstNumbers[firstNumbers.Count - 1]);
                firstNumbers.RemoveAt(firstNumbers.Count - 1);
            }
            int min = Math.Min(condition[0], condition[1]);
            int max = Math.Max(condition[0], condition[1]);
            List<int> currentNumbers = new List<int>();
            for (int i = 0; i < firstNumbers.Count; i++)
            {
                if(min < firstNumbers[i] && firstNumbers[i]< max) currentNumbers.Add(firstNumbers[i]);
                if (min < secondNumbers[i] && secondNumbers[i] < max) currentNumbers.Add(secondNumbers[i]);
            }

            Console.WriteLine(string.Join(" ",currentNumbers.OrderBy(x => x)));
        }
    }
}
