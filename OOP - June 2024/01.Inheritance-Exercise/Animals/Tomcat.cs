namespace Animals
{
    public class Tomcat : Cat
    {
        public static string DefaultGender = "Male";
        public Tomcat(string name, int age) 
            : base(name, age, DefaultGender)
        {
        }
        public override string ProduceSound() => "MEOW";
    }
}
