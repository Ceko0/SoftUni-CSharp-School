namespace Beesy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] field = new char[matrixSize, matrixSize];
            int beeRow = 0;
            int beeCol = 0;
            int beeEnergy = 15;
            int nectar = 0;
            bool recharging = true;
            for (int i = 0; i < matrixSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    field[i, j] = input[j];
                    if (field[i, j] == 'B')
                    {
                        beeRow = i;
                        beeCol = j;
                    }
                }
            }
            while (true)
            {
                beeEnergy--;
                field[beeRow, beeCol] = '-';
                int currentRow = beeRow;
                int currentCol = beeCol;
                string command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        currentRow--;
                        if (currentRow < 0) currentRow = matrixSize - 1;
                        break;
                    case "down":
                        currentRow++;
                        if (currentRow >= matrixSize) currentRow = 0;
                        break;
                    case "left":
                        currentCol--;
                        if (currentCol < 0) currentCol = matrixSize - 1;
                        break;
                    case "right":
                        currentCol++;
                        if (currentCol >= matrixSize) currentCol = 0;
                        break;
                }
                if (char.IsDigit(field[currentRow, currentCol]))
                {
                    nectar += field[currentRow, currentCol] - '0';
                    field[currentRow, currentCol] = '-';
                }
                if (beeEnergy == 0 && recharging)
                {
                    beeEnergy = nectar - 30;
                    nectar = 30;
                    recharging = false;
                }
                if (field[currentRow, currentCol] == 'H')
                {
                    if (nectar >= 30)
                    {
                        Console.WriteLine($"Great job, Beesy! The hive is full. Energy left: {beeEnergy}");
                    }
                    else
                    {
                        Console.WriteLine("Beesy did not manage to collect enough nectar.");
                    }
                    field[currentRow, currentCol] = 'B';
                    break;
                }
                if (beeEnergy <= 0 && !recharging)
                {
                    Console.WriteLine("This is the end! Beesy ran out of energy.");
                    field[currentRow, currentCol] = 'B';
                    break;
                }
                if (field[currentRow, currentCol] == '-' || char.IsDigit(field[currentRow, currentCol]))
                {
                    field[currentRow, currentCol] = 'B';
                }

                beeRow = currentRow;
                beeCol = currentCol;
            }
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
