namespace SoftUni
{
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using SoftUni.Data;
    using SoftUni.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();

            dbContext.Database.EnsureCreated();

            //change method name here
            string result = RemoveTown(dbContext);

            Console.WriteLine(result);
        }

        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();

        }


        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    Salary = e.Salary.ToString("F2")
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary}");
            }

            return sb.ToString().Trim();
        }

        //05. Employees from Research and Development

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {

            var employees = context
                .Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().Trim();
        }


        //06. Adding a New Address and Updating Employee

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            //Създаваме нов адрес
            Address newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            //Добавяме новия адрес в базата
            context.Addresses.Add(newAddress);
            context.SaveChanges();

            //Намираме служителя с LastName = "Nakov"
            Employee? employee = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
                //Задаваме новия адрес на служителя
                employee.Address = newAddress;
                context.SaveChanges();
            }

            //Връщаме последните 10 адреса по AddressId (низходящо)
            var addresses = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            return string.Join(Environment.NewLine, addresses);

        }

        //07.EmployeesAndProjects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
            .Take(10)  // Вземаме първите 10 служители (без значение от проектите)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager != null ? e.Manager.FirstName : "No manager",
                ManagerLastName = e.Manager != null ? e.Manager.LastName : "",
                Projects = e.EmployeesProjects
                    .Where(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003)
                    .Select(ep => new
                    {
                        ep.Project.Name,
                        StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    })
                    .ToList()
            })
            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                if (e.Projects.Any())  // Ако има проекти, ги извеждаме
                {
                    foreach (var p in e.Projects)
                    {
                        sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}");
                    }
                }
            }

            return sb.ToString().TrimEnd();
        }

        //08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {

            var addresses = context.Addresses
                 .Select(a => new
                 {
                     a.AddressText,
                     TownName = a.Town.Name,
                     EmployeeCount = a.Employees.Count
                 })
                 .OrderByDescending(a => a.EmployeeCount)
                 .ThenBy(a => a.TownName)
                 .ThenBy(a => a.AddressText)
                 .Take(10)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();

        }

        //09. Employee 147
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(ep => ep.Project.Name)
                    .OrderBy(p => p)
                    .ToList()
                })
                .FirstOrDefault();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }

        //10. Departments with More Than 5 Employees
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.
                Departments
                .Where(d => d.Employees.Count > 5)//dep. 5+ employees
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        Employees = d.Employees
                                     .OrderBy(e => e.FirstName)
                                     .ThenBy(e => e.LastName)
                                     .Select(e => new
                                        {
                                            e.FirstName,
                                            e.LastName,
                                            e.JobTitle
                                        })
                                        .ToList()
                    })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        //11. Find Latest 10 Projects
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)  
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
            })
            .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }

            return sb.ToString().TrimEnd();

        }


        //12. Increase Salaries
        public static string IncreaseSalaries(SoftUniContext context)
        {
            // Извличаме всички служители от изброените отдели
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" ||
                            e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" ||
                            e.Department.Name == "Information Services")
                .ToList();

            // Увеличаваме заплатите с 12%
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            // Сортираме по първо и фамилно име
            var sortedEmployees = employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    Salary = e.Salary.ToString("F2")
                })
                .ToList();

      
            StringBuilder sb = new StringBuilder();

            foreach (var employee in sortedEmployees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }

            return sb.ToString().TrimEnd();

        }

        //13. Find Employees by First Name Starting With "Sa"
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Salary = e.Salary.ToString("F2")
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            if (employees.Count == 0)
            {
                return "No employees found.";
            }

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary})");
            }

            return sb.ToString().TrimEnd(); 
        }


        //14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            // Намерам проекта с ID2 и махам всички референции към него в таблицата EmployeesProjects
            var prjToDelete = context
                .Projects
                .FirstOrDefault(p => p.ProjectId == 2);

            if (prjToDelete == null)
            {
                return "Project not found.";
            }

            // Премахвм всички връзки с проекта в EmployeesProjects
            var employeeProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(employeeProjects);

            // Изтривам самия проект
            context.Projects.Remove(prjToDelete);

            // Записвам промените в базата данни
            context.SaveChanges();

            // Извличам имената на първите 10 проекта
            var projects = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            // Събирам имената на проектите в резултат
            StringBuilder sb = new StringBuilder();

            foreach (var prj in projects)
            {
                sb.AppendLine(prj);
            }

            return sb.ToString().TrimEnd();
        }

        //15. Remove Town
        public static string RemoveTown(SoftUniContext context)
        {

            // Намирам града "Seattle"
            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            if (town == null)
            {
                return "Town not found.";
            }

            // Намирам всички адреси в този град
            var addressesInSeattle = context.Addresses.Where(a => a.TownId == town.TownId).ToList();

            // Нулирам AddressId на всички служители, които живеят на тези адреси
            foreach (var address in addressesInSeattle)
            {
                var employeesWithAddress = context.Employees.Where(e => e.AddressId == address.AddressId).ToList();
                foreach (var employee in employeesWithAddress)
                {
                    employee.AddressId = null;  // Премахвам референцията към адреса
                }
            }

            // Премахвам адресите от базата данни
            context.Addresses.RemoveRange(addressesInSeattle);

            // Премахвам града
            context.Towns.Remove(town);

            // Записвам промените в базата данни
            context.SaveChanges();

            // Връщаме броя на изтритите адреси
            return $"{addressesInSeattle.Count} addresses in Seattle were deleted";

        }

    }
}





