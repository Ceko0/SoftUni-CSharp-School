namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
     .Replace(" ", "")
     .ToCharArray();
            Stack<char> parentheses = new();

            for (int i = 0; i < input.Length; i++)
            {
                char currentInput = input[i];
                if (currentInput == '{' || currentInput == '[' || currentInput == '(')
                {
                    parentheses.Push(currentInput);
                }
                else if (currentInput == '}' && parentheses.Any())
                {
                    if ('{' != parentheses.Pop() )
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (currentInput == ']' && parentheses.Any())
                {
                    if ('[' != parentheses.Pop())
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (currentInput == ')' && parentheses.Any())
                {
                    if ('(' != parentheses.Pop())
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
