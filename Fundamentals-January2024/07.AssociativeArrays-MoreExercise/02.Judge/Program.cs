namespace _02.Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> contestList = new Dictionary<string, Dictionary<string, int>>();

            string income = "";
            while ((income = Console.ReadLine()) != "no more time")
            {
                string[] contestInformation = income
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string contestName = contestInformation[1];
                string studentName = contestInformation[0];
                int studentPoints = int.Parse(contestInformation[2]);

                contestList.TryAdd(contestName, new Dictionary<string, int>());
                contestList[contestName].TryAdd(studentName, 0);
                contestList[contestName][studentName] = Math.Max(contestList[contestName][studentName], studentPoints);
            }

            Dictionary<string, int> studentTotalPoints = new Dictionary<string, int>();

            foreach (var (contestName, studentInformation) in contestList)
            {
                Console.WriteLine($"{contestName}: {studentInformation.Count} participants");
                int counter = 1;
                foreach (var (studentName, studentPoints) in studentInformation.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{counter++}. {studentName} <::> {studentPoints}");
                    studentTotalPoints.TryAdd(studentName, 0);
                    studentTotalPoints[studentName] += studentPoints;
                }
            }
            int secondCounter = 1;
            Console.WriteLine("Individual standings:");
            foreach (var (studentName, studentPoints) in studentTotalPoints.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{secondCounter++}. {studentName} -> {studentPoints}");
            }
        }
    }
}
