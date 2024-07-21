using ExplicitInterfaces.interfeces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaces.Models
{
    internal class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Age = age;
            Country = country;
        }

        public string Name { get; }

        public int Age { get; }

        public string Country { get; }
    }
}
