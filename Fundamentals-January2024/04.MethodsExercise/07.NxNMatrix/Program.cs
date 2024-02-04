namespace _07.NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixBorder =int.Parse(Console.ReadLine());

            MatrixMaker(matrixBorder);
        }

        private static void MatrixMaker(int matrixBorder)
        {
            for (int i = 0; i < matrixBorder; i++)
            {
                for (int j = 0; j < matrixBorder; j++)
                {
                    Console.Write(matrixBorder + " ");
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
