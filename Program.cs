// See https://aka.ms/new-console-template for more information
using DataAccess;

Console.WriteLine("Hello, World!");

string connectionString = "";
DepartmentRepository repository = new DepartmentRepository(connectionString);