namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , List<string>> courseList = new Dictionary<string , List<string>>();
            string income = "";
            while ((income = Console.ReadLine()) != "end")
            {
                string[] courseAndUser = income
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string courseName = courseAndUser[0];
                string userName = courseAndUser[1];

                if (!courseList.ContainsKey(courseName))
                {
                    courseList.Add(courseName,new List<string>());
                }
                courseList[courseName].Add(userName);
            }

            foreach (var kvp in courseList)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}\n-- {string.Join("\n-- ", kvp.Value)}");
            }
        }
    }
}
