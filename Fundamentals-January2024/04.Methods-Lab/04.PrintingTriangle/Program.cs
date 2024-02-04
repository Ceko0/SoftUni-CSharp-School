namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int triangleLength = int.Parse(Console.ReadLine());

            PrintingTriangle(triangleLength);
        }

        private static void PrintingTriangle(int triangleLength)
        {
            for (int i = 1; i <= triangleLength; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }

            for (int i = triangleLength -1; i > 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{j} ");
                }
                Console.WriteLine();
            }
        }
    }
}
