using System.Text;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Models.DiverChild;
using NauticalCatchChallenge.Models.FishChild;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private readonly DiverRepository divers = new();
        private readonly FishRepository fishes = new();

        
        public string DiveIntoCompetition(string diverType, string diverName)
        {
            IDiver? diver = diverType == typeof(FreeDiver).Name
                ? diver = new FreeDiver(diverName) 
                : diverType == typeof(ScubaDiver).Name
                ? diver = new ScubaDiver(diverName) 
                : null;
            if (diver == null)
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);

            if (divers.Models.FirstOrDefault(x =>x.Name == diverName) != null)
                return string.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);

            divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            IFish? fish = fishType == typeof(ReefFish).Name
                ? new ReefFish(fishName, points)
                : fishType == typeof(PredatoryFish).Name
                    ? new PredatoryFish(fishName, points)
                    : fishType == typeof(DeepSeaFish).Name
                        ? new DeepSeaFish(fishName, points)
                        : null;
            if (fish == null) 
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);

            if (fishes.Models.FirstOrDefault(x => x.Name == fishName) != null)
            return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);

            fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.Models.FirstOrDefault(x => x.Name == diverName);
            if (diver == null) return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);

            IFish fish = fishes.Models.FirstOrDefault(x => x.Name == fishName);
            if (fish == null) return string.Format(OutputMessages.FishNotAllowed, fishName);

            if (diver.HasHealthIssues) return string.Format(OutputMessages.DiverHealthCheck, diverName);

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                OxygenCheck(diver);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    OxygenCheck(diver);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }

                if (!isLucky)
                {
                     diver.Miss(fish.TimeToCatch);
                     OxygenCheck(diver);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            diver.Hit(fish);
            OxygenCheck(diver);
            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }

        public string HealthRecovery()
        {
            int count = 0;
            foreach (IDiver diver in divers.Models)
            {
                if (diver.HasHealthIssues)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    count++;
                }
            }
            return string.Format(OutputMessages.DiversRecovered, count);
        }

        public string DiverCatchReport(string diverName)
        {
            StringBuilder sb = new();
            foreach (IDiver diver in divers.Models)
            {
                sb.AppendLine(diver.ToString());
                sb.AppendLine("Catch Report:");
                foreach (string fishName in diver.Catch)
                {
                    sb.AppendLine(fishes.GetModel(fishName).ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (IDiver diver in divers.Models
                         .OrderByDescending( x => x.CompetitionPoints)
                         .ThenByDescending(x => x.Catch.Count)
                         .ThenBy(x => x.Name))
            {
                if (!diver.HasHealthIssues) sb.AppendLine(diver.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        private void OxygenCheck(IDiver diver)
        {
            if (diver.OxygenLevel <= 0 && !diver.HasHealthIssues) diver.UpdateHealthStatus();
        }
    }
}
