namespace ExplicitInterfaces.interfeces
{
    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string GetName() => $"{Name}";
    }
}
