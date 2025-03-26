using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml.Linq;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {

        //public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        //{
        //    // Fetch guides who speak Spanish
        //    var guides = context.Guides
        //        .Where(g => g.Language == Language.Spanish)
        //        .Select(g => new
        //        {
        //            FullName = g.FullName,
        //            TourPackages = g.TourPackagesGuides
        //                .Select(tpg => tpg.TourPackage)
        //                .OrderByDescending(tp => tp.Price)
        //                .ThenBy(tp => tp.PackageName)
        //                .Select(tp => new
        //                {
        //                    Name = tp.PackageName,
        //                    Description = tp.Description,
        //                    Price = tp.Price
        //                })
        //                .ToList()
        //        })
        //        .OrderByDescending(g => g.TourPackages.Count)
        //        .ThenBy(g => g.FullName)
        //        .ToList();

        //    // Create the XML structure
        //    var xmlGuides = new XElement("Guides");

        //    foreach (var guide in guides)
        //    {
        //        var xmlGuide = new XElement("Guide",
        //            new XElement("FullName", guide.FullName),
        //            new XElement("TourPackages",
        //                guide.TourPackages.Select(tp => new XElement("TourPackage",
        //                    new XElement("Name", tp.Name),
        //                    new XElement("Description", tp.Description),
        //                    new XElement("Price", tp.Price)
        //                ))
        //            )
        //        );

        //        xmlGuides.Add(xmlGuide);
        //    }

        //    // Create the XML document with the correct declaration
        //    var xmlDoc = new XDocument(
        //        new XDeclaration("1.0", "utf-16", "yes"), // XML declaration with utf-16 encoding
        //        xmlGuides
        //    );

        //    // Convert the XML document to a string with the correct encoding
        //    var stringBuilder = new StringBuilder();
        //    using (var writer = new System.IO.StringWriter(stringBuilder))
        //    {
        //        xmlDoc.Save(writer);
        //    }

        //    return stringBuilder.ToString();
        //}


        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            // Fetch guides who speak Spanish
            var guides = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new GuideExportDto
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Select(tpg => tpg.TourPackage)
                        .OrderByDescending(tp => tp.Price)
                        .ThenBy(tp => tp.PackageName)
                        .Select(tp => new TourPackageExportDto
                        {
                            Name = tp.PackageName,
                            Description = tp.Description,
                            Price = tp.Price
                        })
                        .ToList()
                })
                .OrderByDescending(g => g.TourPackages.Count)
                .ThenBy(g => g.FullName)
                .ToList();

            // Create the XML structure
            var xmlGuides = new XElement("Guides");

            foreach (var guide in guides)
            {
                var xmlGuide = new XElement("Guide",
                    new XElement("FullName", guide.FullName),
                    new XElement("TourPackages",
                        guide.TourPackages.Select(tp => new XElement("TourPackage",
                            new XElement("Name", tp.Name),
                            new XElement("Description", tp.Description),
                            new XElement("Price", tp.Price)
                        ))
                    )
                );

                xmlGuides.Add(xmlGuide);
            }

            // Create the XML document with the correct declaration
            var xmlDoc = new XDocument(
                new XDeclaration("1.0", "utf-16", "yes"), // XML declaration with utf-16 encoding
                xmlGuides
            );

            // Convert the XML document to a string with the correct encoding
            var stringBuilder = new StringBuilder();
            using (var writer = new System.IO.StringWriter(stringBuilder))
            {
                xmlDoc.Save(writer);
            }

            return stringBuilder.ToString();
        }



        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            // Fetch customers who have booked the "Horse Riding Tour" package
            var customers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToList()
                })
                .OrderByDescending(c => c.Bookings.Count)
                .ThenBy(c => c.FullName)
                .ToList();

            // Configure JSON serializer options to avoid escaping special characters
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true, // For pretty-printing the JSON
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // Avoid escaping special characters
            };

            // Serialize the data to JSON
            string jsonOutput = JsonSerializer.Serialize(customers, jsonOptions);
            return jsonOutput;
        }


    }
}
