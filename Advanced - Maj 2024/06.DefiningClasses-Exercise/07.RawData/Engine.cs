namespace _07.RawData
{
    internal class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            Speed = speed;
            Power = power;
        }

        public int Speed { get => speed; set => this.speed = value; }
        public int Power { get => power; set => this.power = value; }
    }
}
