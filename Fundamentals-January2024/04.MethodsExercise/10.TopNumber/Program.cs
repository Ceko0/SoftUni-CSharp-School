namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int checkEnd = int.Parse(Console.ReadLine());

            ChekTopNumber(checkEnd);
        }

        private static void ChekTopNumber(int checkEnd)
        {
            for (int i = 1; i <= checkEnd; i++)
            {
                int checkCounter = 0;
                string checkEndDigits = i.ToString();
                int digitSum = 0;
                for (int j = 0; j < checkEndDigits.Length; j++)
                {
                    digitSum += checkEndDigits[j] - '0';
                }

                if (digitSum % 8 == 0)
                {
                    checkCounter++;
                }

                foreach (char digit in checkEndDigits)
                {
                    if (digit % 2 == 1)
                    {
                        checkCounter++;
                        break;
                    }
                }
                if (checkCounter >= 2)
                    Console.WriteLine(i);
            }
        }
    }
}
