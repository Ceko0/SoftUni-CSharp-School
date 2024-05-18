namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                );
            int boxCapacity = int.Parse(Console.ReadLine());

            int boxCounter = 1;
            int currentCapacity = 0;
            while (clothes.Any())
            {
                if (boxCapacity == clothes.Peek())
                {
                    clothes.Pop();
                    boxCounter++;
                }
                else if (boxCapacity < currentCapacity + clothes.Peek())
                {
                    boxCounter++;
                    currentCapacity = 0;
                }
                else
                {
                    currentCapacity += clothes.Pop();
                }
            }
            Console.WriteLine(boxCounter);
        }
    }
}
