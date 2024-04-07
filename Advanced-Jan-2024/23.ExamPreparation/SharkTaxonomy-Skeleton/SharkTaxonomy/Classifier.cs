using System;
using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        //private List<Shark> species;// не знам защо не върви

        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();//направо тук без филд стана
        }

        public int Capacity { get; set; }

        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public void AddShark(Shark newShark)
        {
            if (Capacity == Species.Count || Species.Any(shark => shark.Kind == newShark.Kind))
            {
                return;
            }
            Species.Add(newShark);
        }

        public bool RemoveShark(string kind)
        {
            Shark foundedSharksKind = Species.FirstOrDefault(n => n.Kind == kind);

            if (foundedSharksKind == null)
            {
                return false;
            }
            else
            {
                Species.Remove(foundedSharksKind);
                return true;
            }
        }

        public string GetLargestShark()
        {
            Shark shark = Species.OrderByDescending(l => l.Length).First();

            //return shark.Length.ToString();
            return shark.ToString();

        }

        public double GetAverageLength()
        {
            return Species.Average(l => l.Length);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");

            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }

}
