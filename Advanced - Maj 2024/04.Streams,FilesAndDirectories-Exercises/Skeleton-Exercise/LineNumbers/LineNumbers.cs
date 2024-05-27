namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            using(StreamReader reader = new StreamReader(inputFilePath))
            {
                using(StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    List<string> text = new();
                    int counter = 1;
                    string line = string.Empty;
                    while((line = reader.ReadLine()) != null)
                    {
                        StringBuilder sb = new(); 
                        char[] lineCharacters = line.ToCharArray();
                        int letterCounter = 0;
                        int punctuationCount = 0;
                        foreach(char c in lineCharacters)
                        {
                            if(char.IsLetter(c))
                            {
                                letterCounter++;
                            }
                            if (char.IsPunctuation(c))
                            {
                                punctuationCount++;
                            }
                        }
                        sb.Append($"Line {counter++}: {line} ({letterCounter})({punctuationCount})");
                        writer.WriteLine( sb.ToString() );
                    }

                }
            }
        }
    }
}
