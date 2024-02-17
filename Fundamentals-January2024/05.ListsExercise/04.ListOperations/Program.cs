namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                List<string> commands = input
                    .Split()
                    .ToList();
                int lastIndex = numbers.Count - 1;
                switch (commands[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        int position = int.Parse(commands[2]);
                        if (RangeCheck(position , lastIndex ))
                            numbers.Insert(position, int.Parse(commands[1]));
                        else Console.WriteLine("Invalid index");
                        break;
                    case "Remove":
                        position = int.Parse(commands[1]);
                        if (RangeCheck(position, lastIndex))
                            numbers.RemoveAt(int.Parse(commands[1]));
                        else Console.WriteLine("Invalid index");
                        break;
                    case "Shift":
                        numbers = shifting(numbers , commands);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ",numbers));
        }

        static bool RangeCheck(int position, int lastIndex)
        {
            return (position >= 0 && position <= lastIndex);
        }
        private static List<int> shifting(List<int> numbers, List<string> commands)
        {
            int count = int.Parse(commands[2]) ;
            int lastIndex = numbers.Count - 1;

                int numberToMove = 0;
                if (commands[1] == "right")
                {
                    for (int j = 0; j < count; j++)
                    {
                        numberToMove = numbers[lastIndex];
                        int i = numbers.Count - 1;
                        for (; i > 0; i--)
                        {
                            numbers[i] = numbers[i - 1];
                        }

                        numbers[i] = numberToMove;
                    }
                }
                else if (commands[1] == "left")
                {
                    
                    for (int j = 0; j < count; j++)
                    {
                        numberToMove = numbers[0];
                        int i = 0;
                        for (; i < numbers.Count - 1; i++)
                        {
                            numbers[i] = numbers[i + 1];
                        }

                        numbers[i] = numberToMove;
                    }
                }
            
            else Console.WriteLine("Invalid index");

            return numbers;
        }
    }
}
