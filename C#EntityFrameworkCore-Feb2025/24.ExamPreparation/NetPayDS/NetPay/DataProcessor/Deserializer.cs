using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        //XML
        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            // Десериализация на XML данните в списък от HouseholdDto обекти
            var householdsDto = XmlHelper.Deserialize<List<HouseholdDto>>(xmlString, "Households");

            if (householdsDto == null)
            {
                return "Error! Invalid XML format.";
            }

            foreach (var householdDto in householdsDto)
            {
                try
                {
                    // Валидация на данните
                    if (string.IsNullOrWhiteSpace(householdDto.ContactPerson) ||
                        householdDto.ContactPerson.Length < 5 || householdDto.ContactPerson.Length > 50)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (!string.IsNullOrWhiteSpace(householdDto.Email) &&
                        (householdDto.Email.Length < 6 || householdDto.Email.Length > 80))
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (string.IsNullOrWhiteSpace(householdDto.Phone) ||
                        !Regex.IsMatch(householdDto.Phone, @"^\+\d{3}/\d{3}-\d{6}$"))
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    // Проверка за дублиране
                    bool isDuplicate = context.Households
                        .Any(h => h.ContactPerson == householdDto.ContactPerson ||
                                   h.Email == householdDto.Email ||
                                   h.PhoneNumber == householdDto.Phone);

                    if (isDuplicate)
                    {
                        output.AppendLine("Error! Data duplicated.");
                        continue;
                    }

                    // Създаване на нов Household обект
                    var household = new Household
                    {
                        ContactPerson = householdDto.ContactPerson,
                        Email = householdDto.Email,
                        PhoneNumber = householdDto.Phone
                    };

                    // Добавяне на Household обекта към базата данни
                    context.Households.Add(household);
                    context.SaveChanges();

                    // Добавяне на съобщение за успешен импорт
                    output.AppendLine($"Successfully imported household. Contact person: {household.ContactPerson}");
                }
                catch (ArgumentException ex)
                {
                    output.AppendLine(ex.Message);
                }
                catch (DbUpdateException ex)
                {
                    output.AppendLine("Error! Database update failed.");
                }
                catch (Exception ex)
                {
                    output.AppendLine("Error! Unexpected error occurred during import.");
                }
            }

            return output.ToString().TrimEnd();
        }

        //JSON
        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            // Десериализация на JSON данните в списък от ExpenseDto обекти
            var expensesDto = JsonConvert.DeserializeObject<List<ExpenseDto>>(jsonString);

            if (expensesDto == null)
            {
                return "Error! Invalid JSON format.";
            }

            foreach (var expenseDto in expensesDto)
            {
                try
                {
                    // Валидация на данните
                    if (string.IsNullOrWhiteSpace(expenseDto.ExpenseName) ||
                        expenseDto.ExpenseName.Length < 5 || expenseDto.ExpenseName.Length > 50)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (expenseDto.Amount < 0.01m || expenseDto.Amount > 100000m)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (!DateTime.TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate))
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (!Enum.TryParse(expenseDto.PaymentStatus, out PaymentStatus paymentStatus))
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    // Допълнителна валидация за HouseholdId и ServiceId
                    if (expenseDto.HouseholdId <= 0)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (expenseDto.ServiceId <= 0)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    // Проверка за съществуващи записи във външните ключове
                    bool householdExists = context.Households.Any(h => h.Id == expenseDto.HouseholdId);
                    bool serviceExists = context.Services.Any(s => s.Id == expenseDto.ServiceId);

                    if (!householdExists)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    if (!serviceExists)
                    {
                        throw new ArgumentException("Invalid data format!");
                    }

                    // Създаване на нов Expense обект
                    var expense = new Expense
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = dueDate,
                        PaymentStatus = paymentStatus,
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId
                    };

                    // Добавяне на Expense обекта към базата данни
                    context.Expenses.Add(expense);
                    context.SaveChanges();

                    // Добавяне на съобщение за успешен импорт
                    output.AppendLine($"Successfully imported expense. {expense.ExpenseName}, Amount: {expense.Amount:F2}");
                }
                catch (ArgumentException ex)
                {
                    output.AppendLine("Invalid data format!");
                }
                catch (DbUpdateException ex)
                {
                    output.AppendLine("Invalid data format!");
                }
                catch (Exception ex)
                {
                    output.AppendLine("Invalid data format!");
                }
            }

            return output.ToString().TrimEnd();
        }

        //helper method
        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
