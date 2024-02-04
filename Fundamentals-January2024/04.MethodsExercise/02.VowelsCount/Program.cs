namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();
            Console.WriteLine(vowelsOrConsonantCounter(income));

        }

        static int vowelsOrConsonantCounter(string income)
        {
            int counterVowel = 0;
            int counterConsonant = 0;
            for (int i = 0; i < income.Length; i++)
            {
                string currentLetter = income[i].ToString();
                _ = currentLetter == "a" ? counterVowel++ :
                    currentLetter == "e" ? counterVowel++ :
                    currentLetter == "u" ? counterVowel++ :
                    currentLetter == "i" ? counterVowel++ :
                    currentLetter == "o" ? counterVowel++ :
                    currentLetter == "A" ? counterVowel++ :
                    currentLetter == "E" ? counterVowel++ :
                    currentLetter == "U" ? counterVowel++ :
                    currentLetter == "I" ? counterVowel++ :
                    currentLetter == "O" ? counterVowel++ : 
                    counterConsonant++;
            }
            //return counterConsonant;
            return counterVowel;
        }
    }
}
