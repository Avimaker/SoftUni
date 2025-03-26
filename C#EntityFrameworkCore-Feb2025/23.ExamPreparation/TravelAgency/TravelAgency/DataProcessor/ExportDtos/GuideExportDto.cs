using System;
namespace TravelAgency.DataProcessor.ExportDtos
{
    public class GuideExportDto
    {
        public string FullName { get; set; } = string.Empty;
        public List<TourPackageExportDto> TourPackages { get; set; } = new();
    }

    public class TourPackageExportDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}

