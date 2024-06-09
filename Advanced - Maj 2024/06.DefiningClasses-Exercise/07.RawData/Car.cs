namespace _07.RawData
{
    internal class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;
        public string Model { get => model; set => this.model = value; }
        public Engine Engine { get => engine; set => this.engine = value; }
        public Cargo Cargo { get => cargo; set => this.cargo =value; }
        public Tire[] Tires { get => tires; set => this.tires = value; }
        public Car()
        {

        }
        public Car(string model, int engineSpeed, int enginePower, int cargoWeigth, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine = new(engineSpeed, enginePower);
            Cargo = new(cargoType, cargoWeigth);
            Tires = new Tire[]
            {
                 new Tire(tire1Age, tire1Pressure),
                 new Tire(tire2Age, tire2Pressure),
                 new Tire(tire3Age, tire3Pressure),
                 new Tire(tire4Age, tire4Pressure)
            };
        }
        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
