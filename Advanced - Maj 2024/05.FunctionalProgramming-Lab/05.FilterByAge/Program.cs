
using System;



List<Person> people = ReadPeople();
string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
string format = Console.ReadLine();
Action<Person> printer = CreatePrinter(format);

PrintFilteredPeople(people, filter, printer);

void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
{
    foreach (Person person in people)
    {
        if (filter(person))
        {
            printer(person);
        }
    }
}

Action<Person> CreatePrinter(object format)
{
    
        switch (format) 
        {
            case "name age":
                return p => Console.WriteLine($"{p.Name} - {p.Age}");
                break;
            case "name":
                return p => Console.WriteLine(p.Name);
                break;
            case "age":
                return p => Console.WriteLine(p.Age);
                break;            
        }        
    
    return null;
}
Func<Person, bool> CreateFilter(string condition, int ageThreshold)
{
    switch (condition)
    {
        case "younger":
            return p => p.Age < ageThreshold;            
        case "older":
            return p => p.Age >= ageThreshold;            
        default: 
            return null;
    }
   
}
List<Person> ReadPeople()
{
    int peopleCount = int.Parse(Console.ReadLine());
    List<Person> peoples = new();

    for (int i = 0; i < peopleCount; i++)
    {
        string[] peopleInfo = Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries);
        string name = peopleInfo[0];
        int age = int.Parse(peopleInfo[1]);
        Person person = new Person();
        person.Name = name;
        person.Age = age;
        peoples.Add(person);       
    }
    return peoples;
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

