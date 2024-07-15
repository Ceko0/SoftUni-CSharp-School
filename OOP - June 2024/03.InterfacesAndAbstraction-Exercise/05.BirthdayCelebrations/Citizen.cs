namespace BorderControl
{
    internal class Citizen : IIdentifiable , IBirthdatable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get;}

        public string Birthdate { get; }
    }
}