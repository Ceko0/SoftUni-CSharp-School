namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> output = new();

            while(numbers.Any())
            {
                int currentNumber = numbers.Dequeue();
                if (currentNumber % 2 == 0)
                {
                    output.Enqueue(currentNumber);
                }
            }
            Console.WriteLine(string.Join(", " , output));
        }
    }
}
