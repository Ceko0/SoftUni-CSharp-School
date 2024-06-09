using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;       
        public Parking(int capacity )
        {
            cars = new();
            this.capacity = capacity;            
        }
        public int Count { get => this.cars.Count;  }
        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (cars.Count == capacity)
            {
                return "Parking is full!";
                
            }
            
                cars.Add(car);                
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            
        }
        public string RemoveCar(string registrationNumber)
        {
            Car CurrentCar = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (CurrentCar != null)
            {
                cars.Remove(CurrentCar);                
                return $"Successfully removed {registrationNumber}";
            }
            
                return "Car with that registration number, doesn't exist!";
            
        }        
        public Car GetCar(string registrationNumber)
        {
            Car CurrentCar = cars.FirstOrDefault( x => x.RegistrationNumber == registrationNumber);
            return CurrentCar;
        }
        public void RemoveSetOfRegistrationNumbers(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                 RemoveCar(registrationNumber);                
            }         
        }
    }
}
