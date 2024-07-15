using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; }

        public string Model { get; }

        public string Color { get; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            sb.AppendLine(Start());
            sb.Append(Stop());

            return sb.ToString();
        }
    }
}
