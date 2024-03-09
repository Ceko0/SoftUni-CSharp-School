
namespace _04.Students
{
    class Students
    {
        public Students(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            List<Students> studentsList = new List<Students>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] information = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                studentsList.Add(new Students(information[0], information[1], double.Parse(information[2])));
            }

            foreach (var student in studentsList.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine(student);
            }
        }
    }
}
