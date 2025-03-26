using System.Globalization;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            // Извличане на домакинства, които имат поне един разход с PaymentStatus различен от "Paid"
            var households = context.Households
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != PaymentStatus.Paid))
                .Select(h => new HouseholdDto
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != PaymentStatus.Paid) // Филтриране на неплатените разходи
                        .OrderBy(e => e.DueDate) // Подреждане на разходите по DueDate
                        .ThenBy(e => e.Amount) // Ако датите са еднакви, подреждане по Amount
                        .Select(e => new ExpenseDto
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2", CultureInfo.InvariantCulture), // Форматиране на Amount до два знака след десетичната запетая
                            PaymentDate = e.DueDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), // Форматиране на датата
                            ServiceName = e.Service.ServiceName
                        })
                        .ToArray()
                })
                .OrderBy(h => h.ContactPerson) // Подреждане на домакинствата по ContactPerson
                .ToArray();

            // Сериализация на данните в XML формат
            string xmlString = XmlHelper.Serialize(households, "Households");

            return xmlString;
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            // Извличане на всички услуги заедно с техните доставчици
            var services = context
                .Services
                .Select(s => new
                {
                    ServiceName = s.ServiceName,
                    Suppliers = s.SuppliersServices
                        .Select(ss => new
                        {
                            ss.Supplier.SupplierName
                        })
                        .OrderBy(ss => ss.SupplierName) // Подреждане на доставчиците по име
                        .ToList()
                })
                .OrderBy(s => s.ServiceName) // Подреждане на услугите по име
                .ToList();

            // Сериализация на данните в JSON формат
            string jsonString = JsonConvert.SerializeObject(services, Formatting.Indented);

            return jsonString;
        }
    }
}
