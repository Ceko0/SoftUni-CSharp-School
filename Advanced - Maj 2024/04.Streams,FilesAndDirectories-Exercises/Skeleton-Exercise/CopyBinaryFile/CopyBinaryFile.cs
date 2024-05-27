namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(inputFilePath, FileMode.Open)))
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;

                    while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
