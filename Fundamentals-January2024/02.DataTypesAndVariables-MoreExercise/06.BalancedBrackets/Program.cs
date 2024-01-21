namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lineCounter = int.Parse(Console.ReadLine());

            int openingBrackets = 0;
            int closingBrackets = 0;
            bool isBalanced = true;

            for (int i = 0; i < lineCounter; i++)
            {
                string income = Console.ReadLine();

                if (income == "(")
                { 
                    openingBrackets++;
                }
                else if (income == ")") 
                {
                    closingBrackets++;
                }
                if (closingBrackets > openingBrackets)
                {
                    isBalanced = false;
                }

                if (openingBrackets == closingBrackets + 2)
                {
                    isBalanced = false;
                }
                else if (closingBrackets == openingBrackets + 2)
                {
                    isBalanced = false;
                }
            }
            if (isBalanced)
            {
                if (openingBrackets > 0)
                {
                    if (openingBrackets == closingBrackets)
                    {
                        Console.WriteLine("BALANCED");
                    }
                    else
                    {
                        Console.WriteLine("UNBALANCED");
                    }
                }
                else
                {
                    Console.WriteLine("UNBALANCED");
                }
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
