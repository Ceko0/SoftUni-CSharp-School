namespace _02.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCounter = int.Parse(Console.ReadLine());

            int[] previousRow =new int[rowCounter];
            previousRow[0] = 1;
            for (int i = 0; i < rowCounter ; i++)
            {
                int previousNumber = 0;
                int j = 0;
                foreach (int number in previousRow)
                {
                    if (previousRow[j] != 0)
                    {
                        Console.Write($"{previousRow[j]} ");
                    }
                    previousRow[j] = previousNumber + number;
                    j++;
                    previousNumber = number;
                }
                Console.WriteLine();
            }
        }
    }
}
