using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.ClimberChild;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller :IController
    {
        private IRepository<IPeak> peaks = new PeakRepository();
        private IRepository<IClimber> climbers = new ClimberRepository();
        private IBaseCamp baseCamp = new BaseCamp();
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            if (peaks.Get(name) != null) 
                return string.Format(OutputMessages.PeakAlreadyAdded, name);

            if (!(difficultyLevel == "Extreme" || difficultyLevel == "Hard" || difficultyLevel == "Moderate"))
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid, difficultyLevel);

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(peak);
            return string.Format(OutputMessages.PeakIsAllowed, name ,typeof(PeakRepository).Name);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber climber;
            if (climbers.Get(name) != null)
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, typeof(ClimberRepository).Name);

            if (isOxygenUsed) climber = new OxygenClimber(name);
            else climber = new NaturalClimber(name);

            climbers.Add(climber);
            baseCamp.ArriveAtCamp(name);
            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);

        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber climber = climbers.Get(climberName);
            if (climber == null) return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);

            IPeak peak = peaks.Get(peakName);
            if (peak == null) return string.Format(OutputMessages.PeakIsNotAllowed, peakName);

            string name = baseCamp.Residents.FirstOrDefault( x => x ==climberName);
                if (name == null)
                    return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            

            if (peak.DifficultyLevel == "Extreme" && climber.GetType() == typeof(NaturalClimber))
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);

            baseCamp.LeaveCamp(climberName);

            climber.Climb(peak);

            if (climber.Stamina == 0) return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            
            baseCamp.ArriveAtCamp(climberName);
            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            int climberInBaseCamp = baseCamp.Residents.Count;
            string name = baseCamp.Residents.FirstOrDefault(x => x ==climberName);
            if (name == null) return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);

            IClimber climber = climbers.Get(climberName);
            if (climber.Stamina == 10) return string.Format(OutputMessages.NoNeedOfRecovery, climberName);

            climber.Rest(daysToRecover);

            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string BaseCampReport()
        {
            StringBuilder sb = new();
            if (baseCamp.Residents.Count == 0) return "BaseCamp is currently empty.";
            sb.AppendLine("BaseCamp residents:");
            List<IClimber> orderedClimbers = new();
            foreach (string name in baseCamp.Residents)
            {
                IClimber climber = climbers.Get(name);
                orderedClimbers.Add(climber);
            }

            foreach (IClimber climber in orderedClimbers.OrderBy(x => x.Stamina))
            {
                sb.AppendLine(
                    $"Name: {climber.Name}, Stamina: {climber.Stamina}, Count of Conquered Peaks: {climber.ConqueredPeaks.Count}");
            }
            
            return sb.ToString();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");

            var sortedClimbers = climbers.All
                .OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(c => c.Name);

            foreach (var climber in sortedClimbers)
            {
                sb.AppendLine(climber.ToString());
                foreach (var peak in peaks.All.OrderByDescending(p => p.Elevation))
                {
                    string isValidPeak = climber.ConqueredPeaks.FirstOrDefault( x => x == peak.Name);
                    if (isValidPeak != null) sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
    
}
