﻿using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tire) 
            : this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tire;
        }

        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tire[] tires;

        public string Make { get => make; set => this.make = value; }
        public string Model { get => model; set => this.model = value; }
        public int Year { get => year; set => this.year = value; }
        public double FuelQuantity { get => fuelQuantity; set => this.fuelQuantity = value; }
        public double FuelConsumption { get => fuelConsumption; set => this.fuelConsumption = value; }
        public Engine Engine { get => engine; set => this.engine = value; }
        public Tire[] Tires { get => tires; set => this.tires = value; }
        public void Drive(double distance)
        {
            if (fuelQuantity - distance * fuelConsumption / 100 > 0)
            {
                fuelQuantity -= distance * fuelConsumption / 100; ;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($" Fuel: {this.FuelQuantity:f2}");
            return sb.ToString();
        }
    }
}
