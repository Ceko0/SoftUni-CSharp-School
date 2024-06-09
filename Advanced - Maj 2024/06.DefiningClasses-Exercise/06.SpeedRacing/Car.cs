namespace _06.SpeedRacing
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance = 0;

        public string  Model { get=> model; set => this.model = value; }  
        public double FuelAmount { get=> fuelAmount; set => this.fuelAmount = value; }  
        public double FuelConsumptionPerKilometer { get=> fuelConsumptionPerKilometer; set => this.fuelConsumptionPerKilometer = value; }  
        public double TravelledDistance { get=> travelledDistance; set => this.travelledDistance = value; }  

        public void drive(double kilometers)
        {
            double needFuel = kilometers * this.fuelConsumptionPerKilometer;
            if (needFuel <= this.fuelAmount)
            {
                this.fuelAmount -= needFuel;
                travelledDistance += kilometers;
                return;
            }
            Console.WriteLine("Insufficient fuel for the drive");            
        }
        public override string ToString()
        {
            return $"{model} {fuelAmount:f2} {travelledDistance}";
        }
    }
}
