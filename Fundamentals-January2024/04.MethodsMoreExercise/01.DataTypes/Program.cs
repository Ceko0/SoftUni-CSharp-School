namespace _01.DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();
            string valueIncome = Console.ReadLine();
            incomeChecke(income, valueIncome);
        }

        private static void incomeChecke(string? income, string? valueIncome)
        {
            if (income == "int")
            {
                Console.WriteLine($"{int.Parse(valueIncome) * 2}");
            }
            else if (income == "real")
            {
                Console.WriteLine($"{double.Parse(valueIncome) *1.5 :f2}");
            }
            else if (income == "string")
            {
                Console.WriteLine($"${valueIncome}$");
            }
        }
    }
}
