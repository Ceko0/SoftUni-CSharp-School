using Interfaces.SoldierInterfece;
using MilitaryElite.SoldierCreator;

namespace MilitaryElite.Models.SoldierTree
{
    public class Soldier : ISoldierCreator, ISoldier 

    {
        public Soldier(int id, string firstName, string lastName)
        {
            if(id <= 0 ) throw new ArgumentException("id");
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("name can`t be empty");
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public override string ToString() => $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
    }
}
