using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

//dotnet ef dbcontext scaffold "Server=localhost,1433; Database=AcademicRecordsDB; User Id=SA; Password=SoftUni2025; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --output-dir Models
