// Create - Add

using _01.SoftUni.Models;
using Microsoft.EntityFrameworkCore;

SoftUniContext softUniContext = new SoftUniContext();

var employee = await softUniContext.Employees.FirstOrDefaultAsync();

var project = new Project()
{
    Name = "Judge System1",
    StartDate = DateTime.Now
};

project.Employees.Add(employee);

await softUniContext.Projects.AddAsync(project);

await softUniContext.SaveChangesAsync();

