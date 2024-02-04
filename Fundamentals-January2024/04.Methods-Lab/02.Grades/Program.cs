using System.Reflection.Metadata.Ecma335;

namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());

            Console.WriteLine(GradeChek(grade));
        }

        static string GradeChek(double grade)
        {
            string gradeDefinition = grade >= 2.00 && grade <= 2.99 ? "Fail" : grade <= 3.49 ? "Poor" : grade <= 4.49 ? "Good" : grade <= 5.49 ? "Very good" : grade <= 6.00 ? "Excellent" : "";
            return gradeDefinition;
        }
    }
}
