using System;
using System.Text;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Invalid input!");
            if (age < 0) throw new ArgumentException("Invalid input!");
            if (string.IsNullOrEmpty(gender)) throw new ArgumentException("Invalid input!");

            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name { get;}
        public int Age { get;}
        public string Gender { get;}

        public virtual string ProduceSound() =>"";
        
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append(ProduceSound());

            return sb.ToString().TrimEnd();
        }
    }
}
