namespace _08.Threeuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] stringInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] combinedInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] doubleInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            MyThreeuple<string, string, string> stringThreeuple = new();
            if (stringInput.Length > 4)
            {
                stringThreeuple = new(stringInput[0] + " " + stringInput[1], stringInput[2], stringInput[3] + " " + stringInput[4]);
            }
            else
            {
                stringThreeuple = new(stringInput[0] + " " + stringInput[1], stringInput[2], stringInput[3]);
            }
            MyThreeuple<string, int, bool> combinedThreeuple = new(combinedInput[0], int.Parse(combinedInput[1]), combinedInput[2] == "drunk");
            MyThreeuple<string , double ,string  > doubleThreeuple = new(doubleInput[0], double.Parse(doubleInput[1]), doubleInput[2]);
            Console.WriteLine(stringThreeuple);
            Console.WriteLine(combinedThreeuple);
            Console.WriteLine(doubleThreeuple);
        }
    }
}
