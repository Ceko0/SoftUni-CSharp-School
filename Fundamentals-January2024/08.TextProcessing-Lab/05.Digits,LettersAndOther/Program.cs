namespace _05.Digits_LettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();
            string digits = new string(income.Where(char.IsDigit).ToArray());
            string letters = new string(income.Where(char.IsLetter).ToArray());
            string others = new string(income.Where(c => !char.IsLetterOrDigit(c)).ToArray());
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
