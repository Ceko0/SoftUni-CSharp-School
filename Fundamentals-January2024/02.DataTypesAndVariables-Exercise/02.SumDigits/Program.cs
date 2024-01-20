namespace _02.SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            int digitSum = 0;
            for (int i = 0; i < number.Length; i++)
            {
                char digit = number[i];
                digitSum += (int)char.GetNumericValue(digit);
            }
            Console.WriteLine(digitSum);
        }
    }
}
