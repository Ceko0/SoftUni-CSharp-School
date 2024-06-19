using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public int Capacity { get; set; }

        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new();
        }

        public List<Shark> Species { get; set; }
        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if (!Species.Contains(shark) && Species.Count < Capacity) Species.Add(shark);
        }
        public bool RemoveShark(string kind)
        {
            Shark currentShark = Species.FirstOrDefault(s => s.Kind == kind);
            if (currentShark != null)
            {
                Species.Remove(currentShark);
                return true;
            }
            return false;
        }
        public string GetLargestShark()
        {
            List<Shark> sortetSpecies = Species.OrderByDescending(x => x.Length).ToList();

            Shark largestShark = sortetSpecies.FirstOrDefault();
            return largestShark.ToString();
        }
        public double GetAverageLength()
        {
            double averageLength = Species.Average(x => x.Length);
            return averageLength;
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (Shark shark in Species)
            {
                sb.AppendLine( shark.ToString() );
            }
            return sb.ToString().TrimEnd();
        }
    }
}
