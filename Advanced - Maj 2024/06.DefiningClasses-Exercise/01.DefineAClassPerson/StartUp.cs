namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int peopleCounter = int.Parse(Console.ReadLine());
            const int age = 30;
            Family family = new Family();
            for (int i = 0; i < peopleCounter; i++)
            {
                Person person = new Person();
                string[] personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                person.Name = personInfo[0];
                person.Age = int.Parse(personInfo[1]);
                family.AddMember(person);
            }
            
            Console.WriteLine(string.Join(Environment.NewLine,family.OlderThen(age)));
        }
    }
}
