using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.Json;
using System.Xml.Linq;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        //public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        //{
        //    throw new NotImplementedException();
        //}

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            var output = new List<string>();
            var xmlDoc = XDocument.Parse(xmlString);

            foreach (var customerElement in xmlDoc.Root.Elements("Customer"))
            {
                try
                {
                    // Extract data from XML
                    var fullName = customerElement.Element("FullName")?.Value;
                    var email = customerElement.Element("Email")?.Value;
                    var phoneNumber = customerElement.Attribute("phoneNumber")?.Value;

                    // Validate required fields
                    if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phoneNumber))
                    {
                        output.Add("Invalid data format!");
                        continue;
                    }

                    // Create customer object
                    var customer = new Customer
                    {
                        FullName = fullName,
                        Email = email,
                        PhoneNumber = phoneNumber
                    };

                    // Validate customer using DataAnnotations
                    var validationContext = new ValidationContext(customer);
                    var validationResults = new List<ValidationResult>();
                    bool isValid = Validator.TryValidateObject(customer, validationContext, validationResults, true);

                    if (!isValid)
                    {
                        output.Add("Invalid data format!");
                        continue;
                    }

                    // Check for duplicates
                    bool isDuplicate = context.Customers.Any(c =>
                        c.FullName == customer.FullName ||
                        c.Email == customer.Email ||
                        c.PhoneNumber == customer.PhoneNumber);

                    if (isDuplicate)
                    {
                        output.Add("Error! Data duplicated.");
                        continue;
                    }

                    // Add customer to database
                    context.Customers.Add(customer);
                    context.SaveChanges();

                    output.Add($"Successfully imported customer - {customer.FullName}");
                }
                catch (Exception ex)
                {
                    output.Add("Invalid data format!");
                }
            }

            return string.Join(Environment.NewLine, output);
        }

        //public static string ImportBookings(TravelAgencyContext context, string jsonString)
        //{
        //    throw new NotImplementedException();
        //}

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            var output = new List<string>();

            // Deserialize JSON string into a list of booking DTOs
            var bookingDtos = JsonSerializer.Deserialize<List<BookingDto>>(jsonString);

            foreach (var bookingDto in bookingDtos)
            {
                try
                {
                    // Parse the booking date
                    if (!DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var bookingDate))
                    {
                        output.Add("Invalid data format!");
                        continue;
                    }

                    // Find the customer by name
                    var customer = context.Customers.FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                    if (customer == null)
                    {
                        output.Add("Invalid data format!");
                        continue;
                    }

                    // Find the tour package by name
                    var tourPackage = context.TourPackages.FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);
                    if (tourPackage == null)
                    {
                        output.Add("Invalid data format!");
                        continue;
                    }

                    // Create the booking entity
                    var booking = new Booking
                    {
                        BookingDate = bookingDate,
                        CustomerId = customer.Id,
                        TourPackageId = tourPackage.Id
                    };

                    // Add the booking to the database
                    context.Bookings.Add(booking);
                    context.SaveChanges();

                    // Add success message to the output
                    output.Add($"Successfully imported booking. TourPackage: {tourPackage.PackageName}, Date: {bookingDate.ToString("yyyy-MM-dd")}");
                }
                catch (Exception ex)
                {
                    output.Add("Invalid data format!");
                }
            }

            return string.Join(Environment.NewLine, output);
        }




        //helpers method
        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
