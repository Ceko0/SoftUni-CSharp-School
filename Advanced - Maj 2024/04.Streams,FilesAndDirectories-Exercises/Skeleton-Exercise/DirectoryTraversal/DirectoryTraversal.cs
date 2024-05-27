namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);
            string outputPathToDesctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            WriteReportToDesktop(reportContent, reportFileName, outputPathToDesctop);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] fileInfo = Directory.GetFiles(inputFolderPath);
            Dictionary<string, Dictionary<string, double>> sortedFile = new();
               
            foreach (string file in fileInfo)
            {
                string fileName= Path.GetFileName(file);
                double fileSize = new FileInfo(file).Length /1024.0;
                string fileExtension = Path.GetExtension(file).ToLower();
                sortedFile.TryAdd(fileExtension, new Dictionary<string, double>());
                sortedFile[fileExtension].TryAdd(file, fileSize);
            }

            StringBuilder sb = new();

            foreach((string extension , Dictionary<string, double> fileInformation) in sortedFile
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x .Key))
            {
                sb.AppendLine(extension);
                foreach ((string fileName , double fileSize) in fileInformation.OrderBy(x => x.Value))
                {
                    sb.AppendLine($"--{fileName} - {Math.Round(fileSize,3)}kb");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName,string outputPathToDesctop)
        {
            File.WriteAllText(outputPathToDesctop, textContent);
        }
    }
}
