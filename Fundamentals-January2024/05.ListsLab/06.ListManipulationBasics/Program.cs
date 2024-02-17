namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commands = command
                    .Split()
                    .ToList();
                numbers = NumbersManipulation(numbers, commands);
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> NumbersManipulation(List<int> numbers, List<string> commands)
        {
            int number = int.Parse(commands[1]);
            
            switch (commands[0] )
            {
                case "Add":
                    numbers.Add(number);
                    break;
                case "Remove":
                    numbers.Remove(number);
                    break;
                case "RemoveAt":
                    numbers.RemoveAt(number);
                    break;
                case "Insert":
                    int index = int.Parse(commands[2]);
                    numbers.Insert(index, number);
                    break;
            }
            return numbers;
        }
    }
}
/*
4 19 2 53 6 43
Add 3
Remove 2
RemoveAt 1
Insert 8 3
end
 */