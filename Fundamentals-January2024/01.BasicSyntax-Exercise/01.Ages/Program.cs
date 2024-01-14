int age = int.Parse(Console.ReadLine());

string output = "";

_ = age >= 0 && age <= 2 ? output = "baby" : age <= 13 ? output = "child" : age <= 19 ? output = "teenager" : age <= 65 ? output = "adult" : output = "elder";

Console.WriteLine(output);