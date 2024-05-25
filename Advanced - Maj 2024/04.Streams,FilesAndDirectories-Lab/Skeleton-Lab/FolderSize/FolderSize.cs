namespace FolderSize
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            double sizeInBytes = directoryInfo
                .GetFiles("*", SearchOption.AllDirectories)
                .Sum(file => file.Length);

            double sizeInKB = sizeInBytes / 1024;

            File.WriteAllText(outputFilePath, $"{sizeInKB} KB");
        }
    }
}
