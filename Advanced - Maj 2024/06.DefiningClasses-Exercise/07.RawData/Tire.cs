namespace _07.RawData
{
    internal class Tire
    {
        private int age;
        private double pressure;

        public Tire(int age, double pressure)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get => age; set => this.age = value; }
        public double Pressure { get => pressure; set => this.pressure = value; }
    }
}
