
string season = Console.ReadLine();
string groupType = Console.ReadLine();
int countOfStudents = int.Parse(Console.ReadLine());
int countOfNights = int.Parse(Console.ReadLine());

string sport = "";
double price = 0;

(sport , price) = (season , groupType) switch
{
    ("Winter", "girls") => ("Gymnastics", countOfNights * 9.60 * countOfStudents),
    ("Winter", "boys") => ("Judo", countOfNights * 9.60 * countOfStudents),
    ("Winter", "mixed") => ("Ski", countOfNights * 10 * countOfStudents),
    ("Spring", "girls") => ("Athletics", countOfNights * 7.20 * countOfStudents),
    ("Spring", "boys") => ("Tennis", countOfNights * 7.20 * countOfStudents),
    ("Spring", "mixed") => ("Cycling", countOfNights * 9.50 * countOfStudents),
    ("Summer", "girls") => ("Volleyball", countOfNights * 15 * countOfStudents),
    ("Summer", "boys") => ("Football", countOfNights * 15 * countOfStudents),
    ("Summer", "mixed") => ("Swimming", countOfNights * 20 * countOfStudents),
};
    price = countOfStudents < 10 ? price *1 :
    countOfStudents < 20 ? price * 0.95 :
    countOfStudents < 50 ? price * 0.85 : 
    countOfStudents >= 50 ? price * 0.50 : price * 1;

Console.WriteLine($"{sport} {price:f2} lv.");