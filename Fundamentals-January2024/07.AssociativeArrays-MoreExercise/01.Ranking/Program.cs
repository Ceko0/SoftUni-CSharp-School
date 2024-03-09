using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace _01.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestList = new Dictionary<string, string>();
            Dictionary<string,Dictionary<string, decimal>> students = new Dictionary<string,Dictionary<string, decimal>>();
            string income = "";
            while ((income = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = income
                    .Split(":", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contestName = contestInfo[0];
                string contestPass = contestInfo[1];

                contestList.TryAdd(contestName, contestPass);
            }

            income = "";
            while ((income = Console.ReadLine()) != "end of submissions")
            {
                string[] contestAndUserInfo = income
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contestName = contestAndUserInfo[0];
                string contestPass = contestAndUserInfo[1];
                string studentName = contestAndUserInfo[2];
                decimal point = decimal.Parse(contestAndUserInfo[3]);

                if (contestList.ContainsKey(contestName) && contestList.ContainsValue(contestPass))
                {
                    students.TryAdd(studentName, new Dictionary<string, decimal>());
                    students[studentName].TryAdd(contestName, 0);
                    students[studentName][contestName] = Math.Max(students[studentName][contestName], point);
                }
            }
            var studentWithMaxPoints = students
                .OrderByDescending(student => student.Value.Sum(entry => entry.Value))
                .First();
            string bestStudentName = studentWithMaxPoints.Key;
            decimal bestStudentPoints = studentWithMaxPoints.Value.Sum(entry => entry.Value);

            Console.WriteLine($"Best candidate is {bestStudentName} with total {bestStudentPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var (student , contestInfo) in students.OrderBy(x =>x.Key))
            {
                Console.WriteLine($"{student}");
                foreach (var (contest , points) in contestInfo.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }

        }
    }
}