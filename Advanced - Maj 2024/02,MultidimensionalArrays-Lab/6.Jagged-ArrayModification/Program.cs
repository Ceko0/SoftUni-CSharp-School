namespace _6.Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixRow = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixRow][];

            for (int i = 0; i < matrixRow; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            
            while (true)
            {
                string[] commands = Console.ReadLine()
                    .Split();
                               
                if (commands[0] == "END")
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        foreach (var colitem in matrix[i])
                        {
                            Console.Write($"{colitem} ");
                        }
                        Console.WriteLine();
                    }
                    break;
                }
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                if ((row >= 0 && row < matrixRow && col >= 0 && col < matrix[row].Length))
                {

                    if (commands[0] == "Add")
                    {
                        matrix[row][col] += int.Parse(commands[3]);
                    }
                    else if (commands[0] == "Subtract")
                    {
                        matrix[row][col] -= int.Parse(commands[3]);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
        }
    }
}
