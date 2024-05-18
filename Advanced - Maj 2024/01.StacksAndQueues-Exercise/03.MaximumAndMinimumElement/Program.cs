namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new();

            int operationCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < operationCount; i++)
            {
                int[] commands = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                switch (commands[0])
                {
                    case 1:
                        numbers.Push(commands[1]);
                        break;
                    case 2:
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case 3:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Max());
                        }
                        break;
                    case 4:
                        if (numbers.Any())
                        {
                            Console.WriteLine(numbers.Min());
                        }
                        break;

                }
            }
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
