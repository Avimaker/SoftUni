using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Data.Models
{
    public class TourPackageGuide
    {
        [Key, Column(Order = 0)]
        public int TourPackageId { get; set; }

        [ForeignKey("TourPackageId")]
        public TourPackage TourPackage { get; set; }

        [Key, Column(Order = 1)]
        public int GuideId { get; set; }

        [ForeignKey("GuideId")]
        public Guide Guide { get; set; }
    }
}

