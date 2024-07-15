namespace BorderControl
{
    internal class Citizen : IIdentifiable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            Id = id;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id { get;}
    }
}