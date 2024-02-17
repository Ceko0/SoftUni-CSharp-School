namespace _02.GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> sumNumbers = new List<int>();
            int i = 0;
            for (; i < numbers.Count /2; i++) 
            {
                sumNumbers.Add(numbers[i] + numbers[numbers.Count - 1 - i]);
            }
            if (numbers.Count % 2 == 1) 
            {
                sumNumbers.Add(numbers[i]);
            }
            Console.WriteLine(string.Join (" ", sumNumbers));
        }
    }
}
