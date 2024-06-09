namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family;
        public Family()
        {
            this.family = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.family.Add(member);
        }
        public Person GetOldestMember() 
        {
            return family
                .OrderByDescending(x => x.Age)
                .FirstOrDefault();
                
        }
        public List<Person> OlderThen(int age)
        {
            return family
                .OrderBy(x => x.Name)
                .Where(x => x.Age > age)
                .ToList();
        }       
    }
}
