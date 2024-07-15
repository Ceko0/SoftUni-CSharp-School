using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.iterfases;

namespace Vehicles.clases
{
    public class Vehicle : IVehicle
    {
        protected Vehicle(double fuel, double consumpion, double tankCapacity)
        {
            Fuel = fuel;
            Consumpion = consumpion;
            TankCapacity = tankCapacity;
        }

        public double Fuel { get; protected set; }

        public virtual double Consumpion { get; private set; }
        public double TankCapacity { get; set; }
        public string Drive(double distance)
        {
            if (Fuel < Consumpion * distance) return $"{GetType().Name} needs refueling";
            Fuel -= distance* Consumpion ;
            return $"{GetType().Name} travelled {distance} km";
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return ;
            }
            if (this.Fuel + fuel <= TankCapacity)
                this.Fuel += fuel;
            else Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
        }
        public override string ToString() => $"{this.GetType().Name}: {this.Fuel:f2}";
    }
}
