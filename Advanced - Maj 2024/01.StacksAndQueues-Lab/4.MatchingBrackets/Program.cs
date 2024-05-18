namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> startIndex = new();

            for (int i = 0; i < input.Length; i++) 
            {
                if (input[i].ToString() == "(")
                {
                    startIndex.Push(i);
                }
                if (input[i].ToString() == ")")
                {
                    string output = string.Empty;
                    for (int j = startIndex.Pop(); j < i+1; j++)
                    {
                        output += input[j];
                    }
                    Console.WriteLine(output);
                }
            }
        }
    }
}
