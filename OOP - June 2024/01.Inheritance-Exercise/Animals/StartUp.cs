using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    Animal animal = CreateAnimal(animalType, animalInfo);
                    if (animal != null)
                    {
                        Console.WriteLine(animal);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static Animal CreateAnimal(string animalType, string[] animalInfo)
        {
            string name = animalInfo[0];
            int age = int.Parse(animalInfo[1]);
            string gender = animalInfo.Length > 2 ? animalInfo[2] : null;

            return animalType switch
            {
                "Dog" => new Dog(name, age, gender),
                "Frog" => new Frog(name, age, gender),
                "Cat" => new Cat(name, age, gender),
                "Kitten" => new Kitten(name, age),
                "Tomcat" => new Tomcat(name, age),
                _ => throw new ArgumentException("Invalid input!")
            };
        }
    
    }
}
