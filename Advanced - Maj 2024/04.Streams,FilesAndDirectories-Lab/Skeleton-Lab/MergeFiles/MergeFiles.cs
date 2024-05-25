namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using(StreamReader firstInput =  new StreamReader(firstInputFilePath))
            {
                using(StreamReader secondInput = new StreamReader(secondInputFilePath))
                {
                    using(StreamWriter output = new StreamWriter(outputFilePath))
                    {

                        string[] fistLines = firstInput.ReadToEnd().Split(new char[] { '\n', '\r' } , StringSplitOptions.RemoveEmptyEntries);
                        string[] secondLines = secondInput.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                        
                        for (int i = 0; i < Math.Max(fistLines.Length, secondLines.Length); i++)
                        {
                            if(i < fistLines.Length)
                            {
                                output.WriteLine(fistLines[i]);
                            }
                            if(i < secondLines.Length)
                            {
                                output.WriteLine(secondLines[i]);
                            }
                        }
                    }
                }
            }
        }
    }
}
