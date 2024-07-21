using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MyRequired()]
        public string FullName { get; }
        [MyRange(minValue:12 , maxValue: 90)]
        public int Age { get; }
    }
}
