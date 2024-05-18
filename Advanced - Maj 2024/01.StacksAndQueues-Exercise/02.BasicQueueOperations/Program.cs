namespace _02.BasicQueueOperations
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
            Queue<int> numbersToOperate = new();

            for (int i = 0; i < commands[0]; i++)
            {
                numbersToOperate.Enqueue(numbers[i]);
            }
            for (int j=0; j < commands[1]; j++)
            {
                numbersToOperate.Dequeue();
            }
            bool conteins = numbersToOperate.Contains(commands[2]);
            if(conteins )
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbersToOperate.Any())
                {
                    Console.WriteLine(numbersToOperate.Min());
                }
                else
                {
                    Console.WriteLine("0");
                }
            }
        }
    }
}
