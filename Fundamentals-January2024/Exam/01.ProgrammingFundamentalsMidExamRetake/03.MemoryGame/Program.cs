namespace _03.MemoryGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> memoryGame = Console.ReadLine()
                .Split()
                .ToList();

            string income = "";
            int moveCounter = 0;
            while ((income = Console.ReadLine()) != "end")
            {
                moveCounter++;
                List<string> commands = income
                    .Split()
                    .ToList();
                int firstIndex = int.Parse(commands[0]);
                int secondIndex = int.Parse(commands[1]);
                int lastIndex = memoryGame.Count - 1;

                if (commands[0] == commands[1] || firstIndex > lastIndex || firstIndex < 0 || secondIndex > lastIndex || secondIndex < 0)
                {
                    Console.WriteLine($"Invalid input! Adding additional elements to the board");
                    string itemToInsert = $"-{moveCounter}a";
                    memoryGame.Insert(memoryGame.Count / 2, itemToInsert);
                    memoryGame.Insert(memoryGame.Count / 2, itemToInsert);
                }
                else
                {
                    if (memoryGame[firstIndex] == memoryGame[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {memoryGame[firstIndex]}!");
                        string letterToRemove = memoryGame[firstIndex];
                        memoryGame.Remove(letterToRemove);
                        memoryGame.Remove(letterToRemove);
                    }
                    else
                    {
                        Console.WriteLine($"Try again!");
                        continue;
                    }
                }

                if (memoryGame.Count == 0)
                {
                    Console.WriteLine($"You have won in {moveCounter} turns!");
                    return;
                }
            }

            Console.WriteLine($"Sorry you lose :(");
            Console.WriteLine(string.Join(" ", memoryGame));
        }
    }
}
