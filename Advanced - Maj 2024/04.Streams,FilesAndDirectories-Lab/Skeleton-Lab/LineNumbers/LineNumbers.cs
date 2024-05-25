namespace LineNumbers
{
    using System.Diagnostics.Metrics;
    using System.IO;
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            using(StreamReader sr = new StreamReader(inputFilePath))
            {
                using(StreamWriter sw = new StreamWriter(outputFilePath))
                {
                    int counter = 1;
                    string line = string.Empty;

                    while((line = sr.ReadLine()) != null)
                    {
                        sw.WriteLine($"{counter++}. {line}");
                    }
                }
            }
        }
    }
}
