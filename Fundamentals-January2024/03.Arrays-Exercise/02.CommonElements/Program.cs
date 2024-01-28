namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine()
                .Split()
                .ToArray();
            string[] secondArray = Console.ReadLine()
                .Split()
                .ToArray();
            string output = "";
            for (int i = 0; i < secondArray.Length; i++)
            {
                for (int j = 0; j < firstArray.Length; j++)
                {
                    if (secondArray[i] == firstArray[j])
                    {
                        output += secondArray[i] + " ";
                    }
                }
            }
            Console.WriteLine(output);
        }
    }
}
