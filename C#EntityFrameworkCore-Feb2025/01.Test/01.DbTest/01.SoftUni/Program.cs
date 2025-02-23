using _01.SoftUni;
using _01.SoftUni.Models;
using Microsoft.EntityFrameworkCore;
using SoftUniContext context = new SoftUniContext();

//SoftUniContext softUniContext = new SoftUniContext();

//var optionsBuilder = new DbContextOptionsBuilder<SoftUniContext>();
//optionsBuilder.UseSqlServer("Server=localhost,1433; Database=SoftUni; User Id=SA; Password=SoftUni2025; TrustServerCertificate=True;");




////Classic LINQ 
//{
//    var employees = from e in context.Employees
//                    where e.DepartmentId == 3
//                    select e;

//    foreach (var employee in employees)
//    {
//        Console.WriteLine(employee.FirstName);
//    }
//}

//// Classic LINQ v2
//{
//    IQueryable<Employee> employees = from e in context.Employees
//                                     where e.DepartmentId == 3
//                                     select e;

//    employees.ToList(); //заявката е изълнена

//    foreach (var employee in employees)
//    {
//        Console.WriteLine(employee.FirstName);
//    }
//}

//// Classic LINQ async
//{
//    IQueryable<Employee> employees = from e in context.Employees
//                                     where e.DepartmentId == 3
//                                     select e;

//    await employees.ToListAsync(); //заявката е изълнена

//    foreach (var employee in employees)
//    {
//        Console.WriteLine(employee.FirstName);
//    }
//}


//// LINQ with Extension async
//{
//    IQueryable<Employee> employees = context.Employees
//        .Where(e => e.DepartmentId == 3);

//    employees = employees.Where(e => EF.Functions.Like(e.FirstName, "A%"));

//    await employees.ToListAsync(); //заявката е изълнена

//    foreach (var employee in employees)
//    {
//        Console.WriteLine(employee.FirstName);
//    }
//}


//// LINQ with Extension async v2
//{
//    var employeesFirstName = await context.Employees
//        .AsNoTracking()
//        .Where(e => e.DepartmentId == 3)
//        .Select(e => e.FirstName)
//        .ToListAsync();


//    foreach (var firstName in employeesFirstName)
//    {
//        Console.WriteLine(firstName);
//    }
//}


//// LINQ with Extension async v3
//{
//    var employeesFirstName = await context.Employees
//        .AsNoTracking()
//        .Where(e => e.DepartmentId == 3)
//        .Select(e => e.FirstName)
//        .FirstOrDefaultAsync();


//    Console.WriteLine(employeesFirstName);

//    //foreach (var firstName in employeesFirstName)
//    //{
//    //    Console.WriteLine(firstName);
//    //}
//}


//// LINQ with Extension async v4 with Class EmployeeNameDto 
//{
//    var employeesNames = await context.Employees
//        .AsNoTracking()
//        .Where(e => e.DepartmentId == 3)
//        .Select(e => new EmploeeNameDto()
//        {
//            FirstName = e.FirstName,
//            LastName = e.LastName,
//            MiddleName = e.MiddleName

//        })
//        .FirstOrDefaultAsync();


//    Console.WriteLine($"{employeesNames.FirstName} {employeesNames.MiddleName} {employeesNames.LastName}");

//}


// LINQ with Extension async v4 with anonymus object 
{
    var employeesNames = await context.Employees
        .AsNoTracking()
        .Where(e => e.DepartmentId == 1)
        .Where(e => e.Projects.Any(p => p.EndDate < DateTime.Now))
        .Select(e => new
        {
            e.FirstName,
            e.LastName,
            e.MiddleName,
            e.Salary
        })
        .OrderByDescending(e => e.Salary)
        .FirstOrDefaultAsync();


    Console.WriteLine($"{employeesNames.FirstName} {employeesNames.MiddleName} {employeesNames.LastName} : {employeesNames.Salary:f2}");

}