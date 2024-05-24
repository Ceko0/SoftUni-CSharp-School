namespace _6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row].Length == matrix[row + 1].Length)
                {                    
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] *= 2;
                        matrix[row + 1][col] *= 2;
                    }

                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] /= 2;
                    }
                    for (int col = 0; col < matrix[row+1].Length; col++)
                    {
                        matrix[row+1][col] /= 2;
                    }
                }
            }


            string inpout = string.Empty;
            while ((inpout = Console.ReadLine()) != "End")
            {
                string[] commands = inpout
                    .Split();

                string action = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);
                if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                {
                    switch (action)
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;
                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }

                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
