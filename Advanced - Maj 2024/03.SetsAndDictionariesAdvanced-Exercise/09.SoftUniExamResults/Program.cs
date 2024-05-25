namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> studentInfo = new ();
            HashSet<string> bannList = new();
            string income = "";
            Dictionary<string, int> languageInfo = new();
            while ((income = Console.ReadLine()) != "exam finished")
            {
                string[] contestInformation = income
                    .Split("-", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (contestInformation[1] == "banned")
                {
                    bannList.Add(contestInformation[0]);
                    continue;
                }
                string languageName = contestInformation[1];
                string studentName = contestInformation[0];
                int studentPoints = int.Parse(contestInformation[2]);                
               
                studentInfo.TryAdd(studentName, new Dictionary<string, int>());
                studentInfo[studentName].TryAdd(languageName, 0);
                studentInfo[studentName][languageName] = Math.Max(studentInfo[studentName][languageName], studentPoints);
                languageInfo.TryAdd(languageName, 0);
                languageInfo[languageName]++;
            }
            
            Console.WriteLine("Results:");
            var sortedStudents = studentInfo
               .Where(s => !bannList.Contains(s.Key))
               .OrderByDescending(s => s.Value.Values.Max())
               .ThenBy(s => s.Key);

            foreach (var (name, contests) in sortedStudents)
            {
                Console.WriteLine($"{name} | {contests.Values.Max()}");
            }
            Console.WriteLine("Submissions:");
            foreach ((string language , int count ) in languageInfo.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language} - {count}");
            }
        }
    }
}
