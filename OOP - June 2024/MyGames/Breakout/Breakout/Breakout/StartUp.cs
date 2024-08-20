using System.Security.Cryptography.X509Certificates;
using Breakout.models;
using Breakout.Utilities;


namespace Breakout
{
    public class StartUp
    {
        private static int _row { get; set; }
        private static int _col { get; set; }
        public static void Main()
        {

            const int minRow = 20;
            const int minColl = 20;
            const int MaxRow = 70;
            const int MaxColumn = 60;

            int row = 0;
            int col = 0;
            bool inputIsCorrect = true;
            while (inputIsCorrect)
            {
                if (row == 0)
                {
                    Console.WriteLine("Enter size of Playing Board :");
                    Console.WriteLine($"Min row = {minRow}");
                    Console.WriteLine($"Max row = {MaxRow}");
                    row = int.Parse(Console.ReadLine());
                    if (row <= 0 || row > MaxRow)
                    {
                        Console.WriteLine("invalid row parameter, try again!");
                        row = 0;
                        continue;
                    }
                }

                if (col == 0)
                {
                    Console.WriteLine($"Min Coll = {minColl}");
                    Console.WriteLine($"Max Coll = {MaxColumn}");
                    col = int.Parse(Console.ReadLine());
                    if (col <= 0 || col > MaxColumn)
                    {
                        Console.WriteLine("invalid coll parameter, try again!");
                        col = 0;
                        continue;
                    }
                }

                inputIsCorrect = false;
            }
            _row = row;
            _col = col;
            ConsoleWindow.CustomizeConsole();
            Console.BackgroundColor = ConsoleColor.White;
            Engine engine = new(row, col);
            engine.run();
            
        }

        public static void MainTwo()
        {
            Engine engine = new(_row, _col);
            engine.run();
        }
    }
}