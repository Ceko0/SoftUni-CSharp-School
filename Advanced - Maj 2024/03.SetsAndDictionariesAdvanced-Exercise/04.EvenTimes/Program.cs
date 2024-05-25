namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            SortedDictionary<int, int> numbers = new();

            for (int i = 0; i < counter; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(input))
                {
                    numbers.Add(input, 0);
                }
                numbers[input]++;

            }
            int evenNumber = numbers
                .Where(x => x.Value % 2 == 0)
                .FirstOrDefault()
                .Key;
            Console.WriteLine(evenNumber);
        }
    }
}
