namespace _06.StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , List<double>> studentInformation = new Dictionary<string , List<double>>();

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string studentName= Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());
                if (!studentInformation.ContainsKey(studentName))
                {
                    studentInformation.Add(studentName, new List<double>());
                }
                studentInformation[studentName].Add(studentGrade);
            }
            foreach (var student in studentInformation)
            {
                double averageGrade = student.Value.Average();

                if(averageGrade >= 4.50)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
                
            }
        }
    }
}
