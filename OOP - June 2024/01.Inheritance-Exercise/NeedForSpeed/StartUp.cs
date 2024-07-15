using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle V = new(200, 100);
            RaceMotorcycle RM = new(200, 100);
            CrossMotorcycle CM = new(200, 100);
            FamilyCar FC = new(200, 100);
            SportCar SC = new(200, 100);
            Motorcycle M = new(200, 100);
            Car C = new(200, 100);
            Console.WriteLine(V.Fuel);
            Console.WriteLine(RM.Fuel);
            Console.WriteLine(CM.Fuel);
            Console.WriteLine(FC.Fuel);
            Console.WriteLine(SC.Fuel);
            Console.WriteLine(M.Fuel);
            Console.WriteLine(C.Fuel);
            V.Drive(10);
            RM.Drive(10);
            CM.Drive(10);
            FC.Drive(10);
            SC.Drive(10);
            M.Drive(10);
            C.Drive(10);
            Console.WriteLine(V.Fuel);
            Console.WriteLine(RM.Fuel);
            Console.WriteLine(CM.Fuel);
            Console.WriteLine(FC.Fuel);
            Console.WriteLine(SC.Fuel);
            Console.WriteLine(M.Fuel);
            Console.WriteLine(C.Fuel);

        }
    }
}
