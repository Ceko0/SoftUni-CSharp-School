namespace _04.MorseCodeTranslator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseToEnglish = new Dictionary<string, char>()
        {
            {".-", 'A'}, {"-...", 'B'}, {"-.-.", 'C'}, {"-..", 'D'}, {".", 'E'}, {"..-.", 'F'},
            {"--.", 'G'}, {"....", 'H'}, {"..", 'I'}, {".---", 'J'}, {"-.-", 'K'}, {".-..", 'L'},
            {"--", 'M'}, {"-.", 'N'}, {"---", 'O'}, {".--.", 'P'}, {"--.-", 'Q'}, {".-.", 'R'},
            {"...", 'S'}, {"-", 'T'}, {"..-", 'U'}, {"...-", 'V'}, {".--", 'W'}, {"-..-", 'X'},
            {"-.--", 'Y'}, {"--..", 'Z'}, {"|",' '}
        };

            string morseMessage = Console.ReadLine().Trim();

          
            StringBuilder englishMessage = new StringBuilder();
            string[] morseWords = morseMessage.Split(' '); 
            foreach (string morseWord in morseWords)
            {
                if (!string.IsNullOrWhiteSpace(morseWord))
                {
                    if (morseToEnglish.ContainsKey(morseWord))
                    {
                        englishMessage.Append(morseToEnglish[morseWord]);
                    }
                    else
                    {
                        englishMessage.Append('?'); 
                    }
                }
            }
            Console.WriteLine(englishMessage.ToString());
        }
    }
}
