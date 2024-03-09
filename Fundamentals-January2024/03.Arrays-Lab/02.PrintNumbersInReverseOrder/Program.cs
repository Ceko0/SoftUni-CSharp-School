namespace _02.PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int masivLenght = int.Parse(Console.ReadLine());
            int[] numbers = new int[masivLenght];
            for (int i = 0; i < masivLenght; i++)
            {
                numbers.SetValue(int.Parse(Console.ReadLine()), i);
            }

            Array.Reverse(numbers);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
