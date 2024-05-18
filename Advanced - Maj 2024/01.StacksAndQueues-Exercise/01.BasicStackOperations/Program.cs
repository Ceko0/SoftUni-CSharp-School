namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> numbersToOperate = new();

            for (int i = 0; i < commands[0]; i++)
            {
                numbersToOperate.Push(numbers[i]);
            }
            for (int i = 0; i < commands[1]; i++)
            {
                numbersToOperate.Pop();
            }
            bool contains = numbersToOperate.Contains(commands[2]);
            if (contains)
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbersToOperate.Any())
                {
                    int minNumber = numbersToOperate.Min();
                    Console.WriteLine(minNumber);
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
            
        }
    }
}
