namespace ExplicitInterfaces.interfeces
{
    public  interface IResident
    {
        public string Name { get; }
        public string Country { get; }

        public string GetName() => $"Mr/Ms/Mrs {Name}";
    }
}
