
using Microsoft.EntityFrameworkCore;
using ORM;
using ORM.Models;

SoftUniContext softUniContext = new SoftUniContext();

//VAR 1
// не е правилно ползва много ресурс
//var employees = softUniContext
//    .Employees
//    .Include(e => e.Department)
//    .ToList();

//VAR 2
// select - създаваме (list)анонимна колекция от анонимни обекти, по-млко ресурс, по-бързо
//var employees = softUniContext
//    .Employees
//    .Select(e => new
//    {
//        e.FirstName,
//        e.LastName,
//        DepartmentName = e.Department.Name
//    })
//    .ToList();


//foreach (var item in employees)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.DepartmentName}");
//}



//VAR 3
var employee = softUniContext
    .Employees
    .Where(e => e.JobTitle == "Design Engineer")
    .Select(e => new
    {
        e.FirstName,
        e.LastName,
        e.JobTitle,
        DepartmentName = e.Department.Name,
        e.HireDate,
    }).OrderBy(e => e.HireDate)
    //.ToList();
    .FirstOrDefault();

Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - {employee.DepartmentName}");


////.ToList();
//foreach (var item in employees)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - {item.DepartmentName}");
//}

