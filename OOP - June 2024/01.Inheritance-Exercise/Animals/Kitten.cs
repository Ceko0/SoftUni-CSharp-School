namespace Animals
{
    public class Kitten : Cat
    {
        public static string DefaultGender = "Female";
        public Kitten(string name, int age) 
            : base(name, age, DefaultGender)
        {
        }
        public override string ProduceSound() => "Meow";
    }
}
