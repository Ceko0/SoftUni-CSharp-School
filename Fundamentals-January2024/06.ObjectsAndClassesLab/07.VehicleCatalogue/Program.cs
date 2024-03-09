using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace _07.VehicleCatalogue
{
    class VehicleCatalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }

        public VehicleCatalog()
        {
            Cars = new List<Car>();
            Trucks = new List<Truck>();
        }

    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            VehicleCatalog catalog = new VehicleCatalog();
            string input = "";

            while ((input = Console.ReadLine()) != "end")
            {
                string[] information = input.Split("/")
                    .ToArray();
                if (information[0] == "Car")
                {
                    catalog.Cars.Add(new Car(information[1], information[2], int.Parse(information[3])));
                }
                else
                {
                    catalog.Trucks.Add(new Truck(information[1], information[2], int.Parse(information[3])));
                }
            }

            if (catalog.Cars.Any())
            {

                Console.WriteLine("Cars:");
                foreach (var car in catalog.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.Trucks.Any())
            {

                Console.WriteLine("Trucks:");
                foreach (var truck in catalog.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }
}
