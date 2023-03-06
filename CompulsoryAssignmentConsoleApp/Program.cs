// See https://aka.ms/new-console-template for more information
using DataAccess;
using DataAccess.Models;

Console.WriteLine("Hello, World!");

string connectionString = @"Data Source=.;Initial Catalog=Company;Integrated Security=True;TrustServerCertificate=true";
DepartmentRepository repository = new DepartmentRepository(connectionString);

Console.WriteLine("All Departments");
foreach (Department department in await repository.GetAllDepartments())
{
    Console.WriteLine(department);
}

Console.WriteLine("\nDepartment with Id 1:");
Console.WriteLine(await repository.GetDepartment(1));

Console.WriteLine("\n\nCreate new department:");
Console.WriteLine("Input New Dept Name:");
string DName = Console.ReadLine()!;
Console.WriteLine("Input New Dept Manager SSN:");
int DmngSsn = int.Parse(Console.ReadLine()!);
int lastMadeId = await repository.CreateDepartment(DName, DmngSsn);
Console.WriteLine($"Last Created Dept Id: {lastMadeId}");

Console.WriteLine($"\n\nUpdate Dept Name of Department {lastMadeId}:");
Console.WriteLine("Input New Name:");
string name = Console.ReadLine()!;
Console.WriteLine("1. Updated: " + await repository.UpdateDepartmentName(lastMadeId, name));

Console.WriteLine($"\n\nUpdate Dept Manager of Department {lastMadeId}:");
Console.WriteLine("Input New Manger SSN:");
int mngSsn = int.Parse(Console.ReadLine()!);
Console.WriteLine("2. Updated: " + await repository.UpdateDepartmentManager(lastMadeId, mngSsn));

Console.WriteLine($"\n\nUpdated Department with Id {lastMadeId}:");
Console.WriteLine(await repository.GetDepartment(lastMadeId));

Console.WriteLine("\n\nDelete new department:");
Console.WriteLine("3. Deleted: " + await repository.DeleteDepartment(lastMadeId));

Console.WriteLine("All Departments");
foreach (Department department in await repository.GetAllDepartments())
{
    Console.WriteLine(department);
}

Console.ReadKey();
