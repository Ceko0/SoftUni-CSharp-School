namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = string.Empty;
                List<string> text = new();
                int counter = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string pattern = @"[-,.!?]";
                    string replacement = "@";

                    string result = Regex.Replace(line, pattern, replacement);
                    string[] words = result.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(words);
                    string reversedResult = string.Join(' ', words);
                    if (counter++ % 2 == 0)
                    {
                        text.Add(reversedResult);
                    }
                    ;
                }
                StringBuilder sB = new();
                sB.AppendLine(string.Join(Environment.NewLine, text));
                return sB.ToString();
            }
        }
    }
}
