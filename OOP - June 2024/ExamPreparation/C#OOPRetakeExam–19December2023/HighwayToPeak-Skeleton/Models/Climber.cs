using System.Text;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        private const int minStamina = 0;
        private const int MaxStamina = 10;
        private readonly List<string> conqueredPeaks;

        protected Climber(string name, int stamina)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
            if (stamina < minStamina) stamina = 0;
            else if (stamina > MaxStamina) stamina = 10;
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new();
            ConqueredPeaks = conqueredPeaks.AsReadOnly();
        }

        public string Name { get; }
        public int Stamina { get; protected set; }
        public IReadOnlyCollection<string> ConqueredPeaks { get; }

        public void Climb(IPeak peak)
        {
            if (!conqueredPeaks.Contains(peak.Name))
                conqueredPeaks.Add(peak.Name);

            if (peak.DifficultyLevel == "Extreme") Stamina -= 6;
            else if (peak.DifficultyLevel == "Hard") Stamina -= 4;
            else if (peak.DifficultyLevel == "Moderate") Stamina -= 2;
            if (Stamina < 0) Stamina = 0;
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            if (ConqueredPeaks.Count == 0) sb.AppendLine("no peaks conquered");
            else sb.Append($"Peaks conquered: {ConqueredPeaks.Count}");
            return sb.ToString();
        }
    }
}