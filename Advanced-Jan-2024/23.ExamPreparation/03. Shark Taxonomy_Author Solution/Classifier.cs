using System.Dynamic;
using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }

        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public void AddShark(Shark s)
        {
            if(Capacity == Species.Count || Species.Any(shark => shark.Kind == s.Kind))
            {
                return;
            }
            Species.Add(s);
        }

        public bool RemoveShark(string kind) => Species.Remove(Species.FirstOrDefault(s => s.Kind == kind));

        public string GetLargestShark() => Species.OrderByDescending(s => s.Length).FirstOrDefault().ToString();

        public double GetAverageLength() => Species.Average(s => s.Length);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{GetCount} sharks classified:");

            foreach(Shark s in Species )
            {
                sb.AppendLine(s.ToString().Trim());
            }

            return sb.ToString().Trim();
        }
    }
}
