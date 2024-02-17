namespace _01.BonusScoringSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            int numberOflectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double maxStudentBonus = double.MinValue;
            int maxStudentAttended = 0;
            
            for (int i = 1; i <= numberOfStudents; i++)
            {
                int studentAttendance = int.Parse(Console.ReadLine());
                double currentStudentBonus = Math.Ceiling((double)studentAttendance / numberOflectures * (5 + bonus));
                if (currentStudentBonus >= maxStudentBonus)
                {
                    maxStudentBonus = currentStudentBonus;
                    maxStudentAttended = studentAttendance;
                }
            }

            Console.WriteLine($"Max Bonus: {maxStudentBonus}.");
            Console.WriteLine($"The student has attended {maxStudentAttended} lectures.");
        }
    }
}
