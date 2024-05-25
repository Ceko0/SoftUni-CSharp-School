namespace ExtractSpecialBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> bytesToExtract = File.ReadAllLines(bytesFilePath)
                                              .Select(s => Convert.ToByte(s))
                                              .ToHashSet();

            using (FileStream inputStream = new FileStream(binaryFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    var extractedBytes = buffer.Take(bytesRead)
                                               .Where(b => bytesToExtract.Contains(b))
                                               .ToArray();

                    outputStream.Write(extractedBytes, 0, extractedBytes.Length);
                }
            }

        }
    }
}
