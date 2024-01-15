namespace _05.Messages
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string outputLetter = "";
            for (int i = 0; i < counter; i++)
            {
                int digit = int.Parse(Console.ReadLine());
                if (digit == 0) { outputLetter += " "; continue; }
                int digitLenght = digit.ToString().Length;
                int mainDigit = digit % 10;
                int letterDigit = ((mainDigit - 2) * 3) + digitLenght - 1 + 97;
                if (mainDigit >= 8) letterDigit++;
                char letter = (char)letterDigit;
                outputLetter += letter;
            }
            Console.WriteLine(outputLetter);

        }
    }
}
