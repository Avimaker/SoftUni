// Read
using _01.SoftUni.Models;
using Internal;
using Microsoft.EntityFrameworkCore;

SoftUniContext softUniContext = new SoftUniContext();

//// Var 1
////не е правилно ползва много ресурс

//var employees = softUniContext
//    .Employees
//    .Include(e => e.Department)
//    .ToList();

//foreach (var item in employees)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Department}");
//}

//// Var 2
//// select - създаваме (list)анонимна колекция от анонимни обекти, по-млко ресурс, по-бързо
//var employees = softUniContext
//    .Employees
//    .Select(e => new
//                 {
//                     e.FirstName,
//                     e.LastName,
//                     DepartmentName = e.Department.Name
//                 })
//    .ToList();


//foreach (var item in employees)
//{
//    Console.WriteLine($"{item.FirstName} {item.LastName} - {item.DepartmentName}");
//}

// Var 3
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




