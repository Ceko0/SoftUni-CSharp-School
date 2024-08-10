using Handball.Models.Contracts;
using Handball.Models.PlayerChild;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Handball.Models
{
    public class Team :ITeam
    {
        private readonly List<IPlayer> players;
        public Team(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.TeamNameNull);
            Name = name;
            PointsEarned = 0;
            players = new();
            Players = players.AsReadOnly();
        }

        public string Name { get; }
        public int PointsEarned { get; private set; }

        public double OverallRating => players.Count == 0 ? 0 : Math.Round(players.Average(x => x.Rating) , 2);
        
        public IReadOnlyCollection<IPlayer> Players { get; }
        public void SignContract(IPlayer player)
        {
            players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (IPlayer player in players)
            {
                player.IncreaseRating();
            }
        }
        public void Lose()
        {
            foreach (IPlayer player in players)
            {
                player.DecreaseRating();
            }
        }
        public void Draw()
        {
            PointsEarned += 1;
            IPlayer GoalKeeper = players.FirstOrDefault(x => x.GetType().Name == typeof(Goalkeeper).Name);
            GoalKeeper.IncreaseRating();
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append("--Players: ");
            if (players.Count == 0) sb.AppendLine("none");
            foreach (IPlayer player in players)
            {
                sb.Append($"{player.Name}, ");
            }
            return sb.ToString().TrimEnd(' ',',');
        }
    }
}
