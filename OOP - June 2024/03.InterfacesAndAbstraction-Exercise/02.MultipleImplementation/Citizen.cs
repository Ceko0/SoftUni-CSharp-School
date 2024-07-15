namespace PersonInfo
{
    public class Citizen : IPerson, IBirthable,IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Birthdate = birthdate;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Birthdate { get; }
        public string Id { get; }
    }
}
