namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            int[] firstLineOFNumbers = new int[counter];
            int[] secondLineOFNumbers = new int[counter];

            for (int i = 1; i <= counter; i++)
            {

                int[] inputOne = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 1)
                {
                    firstLineOFNumbers[i - 1] = inputOne[0];
                    secondLineOFNumbers[i - 1] = inputOne[1];
                }
                else
                {
                    firstLineOFNumbers[i - 1] = inputOne[1];
                    secondLineOFNumbers[i - 1] = inputOne[0];
                }
            }

            Console.WriteLine(string.Join(" ", firstLineOFNumbers));
            Console.WriteLine(string.Join(" ", secondLineOFNumbers));
        }
    }
}
