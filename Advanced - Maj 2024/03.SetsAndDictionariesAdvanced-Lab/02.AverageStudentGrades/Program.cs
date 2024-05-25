using System.Text;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentRecord = new();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!studentRecord.ContainsKey(input[0]))
                {
                    studentRecord.Add(input[0], new List<decimal>());
                }
                studentRecord[input[0]].Add(decimal.Parse(input[1]));
            }
            foreach ((string name , List<decimal> grades) in studentRecord)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"{name} -> ");
                for (int i = 0; i < grades.Count; i++)
                {
                    sb.Append($"{grades[i]:f2} ");
                }
                sb.Append($"(avg: {grades.Average():f2})");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
