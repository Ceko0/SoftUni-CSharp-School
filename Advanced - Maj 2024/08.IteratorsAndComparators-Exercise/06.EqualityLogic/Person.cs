namespace _06.EqualityLogic
{
    public class Person :IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person? other)
        {
            if (this.Age != other.Age) return this.Age + other.Age;            

            return String.Compare(
                Name, 
                other.Name,
                StringComparison.InvariantCultureIgnoreCase);
        }

        public override bool Equals(object? obj)
        {
            Person other = obj as Person;

            if (other == null) return false;

            return Name == other.Name
                && Age == other.Age;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
    }
}
