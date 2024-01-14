
double budget = double.Parse(Console.ReadLine());
int countOfStudents = int.Parse(Console.ReadLine());
double LightsabersPrice = double.Parse(Console.ReadLine());
double robePrice  = double.Parse(Console.ReadLine());
double beltsPrice = double.Parse(Console.ReadLine());
int freeBelts = countOfStudents / 6;

double neededMoney = LightsabersPrice * Math.Ceiling(countOfStudents *1.1) + countOfStudents * robePrice + (countOfStudents - freeBelts) * beltsPrice;

if (budget >= neededMoney) Console.WriteLine($"The money is enough - it would cost {neededMoney:f2}lv.");
else Console.WriteLine($" John will need {neededMoney - budget :f2}lv more.");