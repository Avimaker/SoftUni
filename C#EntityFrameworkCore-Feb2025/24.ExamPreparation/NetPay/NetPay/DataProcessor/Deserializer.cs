using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";//Е1
        private const string DuplicationDataMessage = "Error! Data duplicated."; //Е2
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";//Е3
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        //02-1  - Create ImportHouseholdsDto
        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            //root name of XML
            const string xmlRootName = "Households";

            //output
            StringBuilder output = new StringBuilder();

            //масив от dto
           ImportHouseholdsDto[]? houseDtos = XmlHelper
                .Deserialize<ImportHouseholdsDto[]>(xmlString, xmlRootName);


            //правим проверка върнало ли сс е нещо и дали изобщо имаме данни 
            if (houseDtos != null && houseDtos.Length > 0)
            {
                //създаваме лист от валидни dto-та
                ICollection<Household> validHouseholds = new List<Household>();

                //ако има данни започваме да обхождаме houseDtos и да ги валидираме с foreach
                foreach (ImportHouseholdsDto houseDto in houseDtos)
                {
                    //правим проверка дали dto-то е валидно? ако не...
                    if (!IsValid(houseDto))
                    {
                        output
                            .AppendLine(ErrorMessage);//добавяме грешка Е1
                        continue;//и пропускаме
                    }

                    //правим проверка дали е дублирано първо с памета и второ с вече добавените валидни dto-тa
                    bool isAlreadyImportHousehold = context
                        .Households
                        .Any(h => h.ContactPerson == houseDto.ContactPerson ||
                                  h.Email == houseDto.Email ||
                                  h.PhoneNumber == houseDto.PhoneNumber);
                    bool isToBeImportedHousehold = validHouseholds
                        .Any(h => h.ContactPerson == houseDto.ContactPerson ||
                                  h.Email == houseDto.Email ||
                                  h.PhoneNumber == houseDto.PhoneNumber);

                    //ако намерим такова домакинство трябва да пропуснем и да добавим грешка Е2
                    if (isAlreadyImportHousehold || isToBeImportedHousehold)
                    {
                        output
                            .AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    // ако сме минали всички валидации създаваме обект от dto
                    Household houseHold = new Household()
                    {
                        ContactPerson = houseDto.ContactPerson,
                        Email = houseDto.Email,
                        PhoneNumber = houseDto.PhoneNumber,
                    };

                    //добавяме валидното dto към списъка с валидни dto-та
                    validHouseholds.Add(houseHold);

                    //изваждаме съобщение с успешно добавения 
                    string successMessage = string
                        .Format(SuccessfullyImportedHousehold, houseDto.ContactPerson);
                    //добавяме в output-a съобщение с успешно добавения 
                    output
                        .AppendLine(successMessage);
                }

                //добавяме в контекста масив с валидни dto-ta
                context.Households.AddRange(validHouseholds); // Faster than calling multiple .Add()

                //добавяме го в db
                context.SaveChanges();
            }

            //вадим инфото
            return output.ToString().TrimEnd();
        }

        //02-2
        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            //създаваме output
            StringBuilder output = new StringBuilder();

            //масив от dto-та - обекти
            ImportExpenseDto[]? expenseDtos = JsonConvert
                .DeserializeObject<ImportExpenseDto[]>(jsonString);

            //ако има данни започваме да обхождаме expenseDtos и да ги валидираме с foreach
            if (expenseDtos != null && expenseDtos.Length > 0)
            {
                //създаваме лист от валидни dto-та
                ICollection<Expense> validExpenses = new List<Expense>();

                //ако има данни започваме да обхождаме expenseDtos и да ги валидираме с foreach
                foreach (ImportExpenseDto expenseDto in expenseDtos)
                {
                    //правим проверка дали dto-то е валидно? ако не...
                    if (!IsValid(expenseDto))
                    {
                        //добавяме грешка Е1
                        output
                            .AppendLine(ErrorMessage);
                        continue;// и пропускаме
                    }

                    //проверяваме дали съществува връзка в db
                    bool householdExists = context
                        .Households
                        .Any(h => h.Id == expenseDto.HouseholdId);
                    bool serviceExists = context
                        .Services
                        .Any(s => s.Id == expenseDto.ServiceId);

                    //ако намерим такова домакинство трябва да пропуснем и да добавим грешка Е1
                    if ((!householdExists) || (!serviceExists))
                    {
                        output
                            .AppendLine(ErrorMessage);
                        continue;
                    }

                    // опитваме да парснем от dto-то DueDate което е стринг към дата с формат зададен "yyyy-MM-dd", ако успееш изкарай dueDate
                    bool isDueDateValid = DateTime
                        .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime dueDate);

                    // опитай се да парснеш PaymentStatus
                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(expenseDto.PaymentStatus, out PaymentStatus paymentStatus);

                    // проверка ако едно от двете bool фейлне трябва да пропуснем и да добавим грешка Е1
                    if ((!isDueDateValid) || (!isPaymentStatusValid))
                    {
                        output
                            .AppendLine(ErrorMessage);
                        continue;
                    }

                    // ако сме минали всички валидации създаваме обект от dto
                    Expense expense = new Expense()
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = dueDate,
                        PaymentStatus = paymentStatus,
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId,
                    };

                    //добавяме валидното dto към списъка с валидни dto-та
                    validExpenses.Add(expense);

                    //изваждаме съобщение с успешно добавения 
                    string successMessage = string
                        .Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("F2"));
                    output
                        .AppendLine(successMessage);
                }

                //добавяме в контекста масив с валидни dto-ta
                context.Expenses.AddRange(validExpenses);
                //перситсваме промените в базата
                context.SaveChanges();
            }

            //вадим инфото
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
