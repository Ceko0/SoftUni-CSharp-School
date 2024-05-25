﻿namespace OddLines
{
    using System.IO;
	
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                using (StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    int counter = 0;
                    string line = string.Empty;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (counter % 2 != 0)
                        {
                            sw.WriteLine(line);
                        }
                        counter++;
                    }
                }

            }
        }
    }
}
