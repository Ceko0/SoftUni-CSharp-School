
        int countOfPeople = int.Parse(Console.ReadLine());
        string grouptype = Console.ReadLine();
        string dayOfWeek = Console.ReadLine();

        double totalPrice = 0;
if (grouptype == "Business " && countOfPeople >= 100) countOfPeople -= 10;

totalPrice = (dayOfWeek, grouptype) switch
{
    ("Friday", "Students") => countOfPeople * 8.45,
    ("Friday", "Business") => countOfPeople * 10.90,
    ("Friday", "Regular") => countOfPeople * 15.0,
    ("Saturday", "Students") => countOfPeople * 9.80,
    ("Saturday", "Business") => countOfPeople * 15.6,
    ("Saturday", "Regular") => countOfPeople * 20.0,
    ("Sunday", "Students") => countOfPeople * 10.46,
    ("Sunday", "Business") => countOfPeople * 16.0,
    ("Sunday", "Regular") => countOfPeople * 22.50,
};

if (grouptype == "Students" && countOfPeople >= 30) totalPrice *= 0.85;
if (grouptype == "Regular " && 10 >= countOfPeople && countOfPeople >= 20) totalPrice *= 0.95;

Console.WriteLine($"Total price: {totalPrice:f2}");