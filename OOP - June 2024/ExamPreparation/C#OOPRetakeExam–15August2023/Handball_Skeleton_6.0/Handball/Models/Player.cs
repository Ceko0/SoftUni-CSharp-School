using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        public Player(string name, double rating)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.PlayerNameNull);
            Name = name;
            Rating = rating;
        }

        public string Name { get; }
        public double Rating { get; protected set; }
        public string Team { get; private set; }
        public void JoinTeam(string name)
        {
            Team = name;
        }
        public abstract void IncreaseRating();
        public abstract void DecreaseRating();
        public override string ToString()
        {
            return $"{GetType().Name}: {Name}{Environment.NewLine}--Rating: {Rating}";
        }
    }
}
