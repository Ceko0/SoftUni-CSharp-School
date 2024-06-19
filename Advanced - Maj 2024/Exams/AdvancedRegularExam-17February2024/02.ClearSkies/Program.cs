namespace _02.ClearSkies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            char[,] airspace = new char[matrixSize, matrixSize];

            int jetRow = 0;
            int jetCol = 0;
            int enemyCount = 0;
            int armor = 300;

            for (int i = 0; i < matrixSize; i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrixSize; j++)
                {
                    airspace[i, j] = input[j];
                    if (airspace[i, j] == 'J')
                    {
                        jetRow = i;
                        jetCol = j;
                    }
                    if (airspace[i, j] == 'E') enemyCount++;
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();
                int currentJetRow = jetRow;
                int currentJetCol = jetCol;
                if (currentJetRow >= matrixSize || currentJetCol >= matrixSize)
                {
                    continue;
                }
                airspace[jetRow, jetCol] = '-';
                switch (direction)
                {
                    case "up":
                        currentJetRow--;
                        break;
                    case "down":
                        currentJetRow++;
                        break;
                    case "right":
                        currentJetCol++;
                        break;
                    case "left":
                        currentJetCol--;
                        break;
                }
                if (airspace[currentJetRow,currentJetCol] == 'E')
                {
                    airspace[currentJetRow, currentJetCol] = 'J';
                    enemyCount--;
                    if (enemyCount == 0)
                    {
                        Console.WriteLine("Mission accomplished, you neutralized the aerial threat!");

                        break;
                    }
                    armor -= 100;
                    if (armor <= 0)
                    {
                        Console.WriteLine($"Mission failed, your jetfighter was shot down! Last coordinates [{currentJetRow}, {currentJetCol}]!");
                        break;
                    }
                }
                else if (airspace[currentJetRow, currentJetCol] == 'R')
                {
                    armor = 300;
                }
                airspace[currentJetRow, currentJetCol] = 'J';
                jetRow = currentJetRow; 
                jetCol = currentJetCol;

            }
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    Console.Write(airspace[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
