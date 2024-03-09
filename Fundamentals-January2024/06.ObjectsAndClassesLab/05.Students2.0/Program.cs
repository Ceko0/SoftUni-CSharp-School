namespace _05.Students2._0
{
    class Students
    {
        public Students(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> finalStudentList = new List<Students>();
            string income;
            while ((income = Console.ReadLine()) != "end")
            {
                string[] studentInformation = income
                    .Split();

                Students student = new Students(studentInformation[0], studentInformation[1], int.Parse(studentInformation[2]), studentInformation[3]);
                string firstNameToCheck = studentInformation[0];
                string lastNameToCheck = studentInformation[1];

                int studentIndex = StudentCheck(finalStudentList, studentInformation);
                if (studentIndex != -1)
                {
                    finalStudentList[studentIndex-1] = student;
                }
                else
                {
                    finalStudentList.Add(student);
                }
            }
            string needTown = Console.ReadLine();
            List<Students> StudentsForOutput = finalStudentList
                .Where(students => students.HomeTown == needTown)
                .ToList();
            foreach (Students students in StudentsForOutput)
            {
                Console.WriteLine($"{students.FirstName} {students.LastName} is {students.Age} years old.");
            }
        }

        private static int StudentCheck(List<Students> finalStudentList, string[] studentInformation)
        {
            int studentcounter = 0;
            foreach (Students students in finalStudentList)
            {
                studentcounter++;
                if (students.FirstName == studentInformation[0] && students.LastName == studentInformation[1])
                {
                    return studentcounter;
                }
            }

            return -1;
        }
    }
}
