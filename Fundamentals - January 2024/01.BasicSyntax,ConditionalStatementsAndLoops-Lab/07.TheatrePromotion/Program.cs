string typeOfDay = Console.ReadLine();
int age = int.Parse(Console.ReadLine());

     if (typeOfDay == "Weekend") Console.WriteLine(age < 0 ? "Error!" : age >= 0 && age <= 18 ? "15$" : age <= 64 ? "20$" : age <= 122 ? "15$" : "Error!");
else if (typeOfDay == "Holiday") Console.WriteLine(age < 0 ? "Error!" : age >= 0 && age <= 18 ?  "5$" : age <= 64 ? "12$" : age <= 122 ? "10$" : "Error!");
else if (typeOfDay == "Weekday") Console.WriteLine(age < 0 ? "Error!" : age >= 0 && age <= 18 ? "12$" : age <= 64 ? "18$" : age <= 122 ? "12$" : "Error!");