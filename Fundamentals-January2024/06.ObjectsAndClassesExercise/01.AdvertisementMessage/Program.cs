using System;
using System.Collections.Generic;

namespace _01.AdvertisementMessage
{

    class Program
    {
        static Random random = new Random();

        static List<string> phrases = new List<string>
        {
            "Excellent product.", "Such a great product.", "I always use that product.",
            "Best product of its category.", "Exceptional product.", "I can't live without this product."
        };

        static List<string> events = new List<string>
        {
            "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
            "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
        };

        static List<string> authors = new List<string>
            { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

        static List<string> cities = new List<string> { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

        static string GenerateAdvertisement()
        {
            string phrase = phrases[random.Next(phrases.Count)];
            string eventText = events[random.Next(events.Count)];
            string author = authors[random.Next(authors.Count)];
            string city = cities[random.Next(cities.Count)];
            return $"{phrase} {eventText} {author} - {city}.";
        }

        static void Main(string[] args)
        {
            int numMessages = int.Parse(Console.ReadLine());

            for (int i = 0; i < numMessages; i++)
            {
                Console.WriteLine(GenerateAdvertisement());
            }
        }
    }
}