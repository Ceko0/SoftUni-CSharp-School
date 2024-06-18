namespace _07.Tuple
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

            MyTuple<string,string> stringTuple = new(stringInput[0] +" "+ stringInput[1] , stringInput[2]);
            MyTuple<string, int> combinedTuple = new(combinedInput[0], int.Parse(combinedInput[1]));
            MyTuple<int , double> doubleTuple = new(int.Parse(doubleInput[0]) , double.Parse(doubleInput[1]));
            Console.WriteLine(stringTuple);
            Console.WriteLine(combinedTuple);
            Console.WriteLine(doubleTuple);
        }
    }
}
