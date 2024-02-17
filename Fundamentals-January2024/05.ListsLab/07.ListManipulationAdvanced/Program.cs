namespace _07.ListManipulationAdvanced
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
            List<int> newNumbers = numbers.ToList();

            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commands = command
                    .Split()
                    .ToList();
              newNumbers = NumbersManipulation(newNumbers, commands);
            }
            if (!(numbers.SequenceEqual(newNumbers)))
            {
                Console.WriteLine(string.Join(" ", newNumbers));
            }
        }

        private static List<int> NumbersManipulation(List<int> numbers, List<string> commands)
        {
            
            List<int> newNumbers = numbers.ToList();
            switch (commands[0])
            {
                case "Add":
                    int number = int.Parse(commands[1]);
                    newNumbers.Add(number);
                    break;
                case "Remove":
                    number = int.Parse(commands[1]);
                    newNumbers.Remove(number);
                    break;
                case "RemoveAt":
                    number = int.Parse(commands[1]);
                    newNumbers.RemoveAt(number);
                    break;
                case "Insert":
                    number = int.Parse(commands[1]);
                    int index = int.Parse(commands[2]);
                    newNumbers.Insert(index, number);
                    break;
                case "Contains":
                    number = int.Parse(commands[1]);
                    bool isInTheList = numbers.Contains(number);
                    if (isInTheList) Console.WriteLine("Yes");
                    else Console.WriteLine("No such number");
                    return newNumbers;
                case "PrintEven":
                case "PrintOdd":
                    Console.WriteLine(string.Join(" " ,ReturnEvenAndOddInList(numbers , commands[0])));
                    break;
                case "GetSum":
                    Console.WriteLine(numbers.Sum());
                    break;
                case "Filter":
                    Console.WriteLine(string.Join(" ", FiltratedNumbers(numbers, commands[1], int.Parse(commands[2]))));
                    break;
            }
            return newNumbers;
        }

        private static List<int> FiltratedNumbers(List<int> numbers, string command, int number)
        {
            List<int> newNumbers = new List<int>();

            switch (command)
            {

                case ">":
                    newNumbers = numbers.FindAll(x => x > number);
                    break;
                case "<":
                    newNumbers = numbers.FindAll(x => x < number);
                    break;
                case ">=":
                    newNumbers = numbers.FindAll(x => x >= number);
                    break;
                case "<=":
                    newNumbers = numbers.FindAll(x => x <= number);
                    break;
            }
            return newNumbers;
        }
        private static List<int> ReturnEvenAndOddInList(List<int> numbers , string command)
        {
            List <int> even = new List<int>();
            List <int> odd = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0) even.Add(numbers[i]);
                else odd.Add(numbers[i]);
            }

            if (command == "PrintEven") return even;
            else return odd;
        }
    }
}
