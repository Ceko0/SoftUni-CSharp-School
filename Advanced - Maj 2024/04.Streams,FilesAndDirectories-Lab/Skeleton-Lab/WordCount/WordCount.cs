namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using(StreamReader firstWords = new StreamReader(wordsFilePath))
            {
                using(StreamReader textToCheck = new StreamReader(textFilePath))
                {
                    using(StreamWriter output =  new StreamWriter(outputFilePath))
                    {
                        string[] words = firstWords.ReadToEnd()
                            .ToLower()
                            .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                        string[] text = textToCheck.ReadToEnd()
                            .ToLower()
                            .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
                            
                        Dictionary<string, int> wordsForOutput = new();
                        foreach(string word in text)
                        {
                            if (words.Contains(word))
                            {
                                wordsForOutput.TryAdd(word, 0);
                                wordsForOutput[word]++;
                            }
                        }
                        foreach((string word , int count) in wordsForOutput.OrderByDescending(x => x.Value))
                        {
                            output.WriteLine($"{word} - {count}");
                        }
                    }
                }
            }
        }
    }
}
