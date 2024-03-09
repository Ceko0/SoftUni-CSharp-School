namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = "";
            while ((income = Console.ReadLine()) != "end")
            {
                string reversString = new string(income.Reverse().ToArray());
             
                Console.WriteLine($"{income} = {reversString}");
            }
        }
    }
}
