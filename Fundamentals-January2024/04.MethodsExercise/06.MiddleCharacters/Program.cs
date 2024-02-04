namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();

            Console.WriteLine(takeMidSimbols(income));
        }

        private static string takeMidSimbols(string? income)
        {
            string simbols = "";
            if (income.Length %2 == 0)
            {
                for (int i = income.Length /2 -1; i < income.Length / 2 + 1; i++)
                {
                    simbols += income[i];
                }
            }
            else
            {
                simbols = income[income.Length/2].ToString();
            }
            return simbols;
        }
    }
}
