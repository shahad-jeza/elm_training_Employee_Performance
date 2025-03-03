using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Diagnostics;

public class EmployeeService
{
    private readonly AppDbContext _context;
    private readonly string _connectionString;

    public EmployeeService(AppDbContext context)
    {
        _context = context;
        _connectionString = "Data Source=EmployeePerformance.db"; // SQLite connection string
    }

    // Method to find employees who have worked on more than 3 projects in the last 6 months
    public void FindEmployeesWithMoreThan3Projects()
    {
        var sixMonthsAgo = DateTime.Now.AddMonths(-6);

        var employees = _context.Employees
            .Where(e => e.EmployeeProjects.Count(ep => ep.Project.ProjectDeadline >= sixMonthsAgo) > 3)
            .ToList();

        foreach (var employee in employees)
        {
            Console.WriteLine($"Employee: {employee.EmployeeName}");
        }
    }

    // Method to retrieve employees and their projects using Dapper
    public void GetEmployeesWithProjects()
    {
        using (IDbConnection db = new SqliteConnection(_connectionString))
        {
            var sql = @"
                SELECT e.EmployeeName, p.ProjectName, p.ProjectDeadline
                FROM Employees e
                JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
                JOIN Projects p ON ep.ProjectId = p.ProjectId";

            var results = db.Query(sql);

            foreach (var result in results)
            {
                Console.WriteLine($"Employee: {result.EmployeeName}, Project: {result.ProjectName}, Deadline: {result.ProjectDeadline}");
            }
        }
    }



// // task 4 : I can't do stroed procdeure since i'm using sqllite so i will be using raw sql query instaed using dapper
//     public void CalculateEmployeeBonuses()
// {
//     using (IDbConnection db = new SqliteConnection(_connectionString))
//     {
//         var sql = @"
//             SELECT EmployeeId, EmployeeName, Salary * PerformanceRating * 0.1 AS Bonus
//             FROM Employees";

//         var results = db.Query(sql);

//         Console.WriteLine("\nEmployee Bonuses:");
//         foreach (var result in results)
//         {
//             Console.WriteLine($"Employee: {result.EmployeeName}, Bonus: {result.Bonus}");
//         }
//     }
// }


public void CalculateEmployeeBonuses()
{
    using (IDbConnection db = new SqliteConnection(_connectionString))
    {
        // Simulate a stored procedure using raw SQL (since i'm using sqlite)
        var sql = @"
            SELECT EmployeeId, EmployeeName, Salary * PerformanceRating * 0.1 AS Bonus
            FROM Employees";

        var results = db.Query(sql);

        Console.WriteLine("\nEmployee Bonuses:");
        foreach (var result in results)
        { // print the employees list with their bounses 
            Console.WriteLine($"Employee: {result.EmployeeName}, Bonus: {result.Bonus}");
        }
    }
}



// get finaincal report with EF core ()for comaprsion task 

public void GetFinancialReportEFCore()
{
    var stopwatch = Stopwatch.StartNew();

    var report = _context.Departments
        .Select(d => new
        {
            DepartmentName = d.DepartmentName,
            TotalSalary = d.Employees.Sum(e => e.Salary),
        })
        .ToList();

    stopwatch.Stop();

    Console.WriteLine("\nFinancial Report (EF Core):");
    foreach (var item in report)
    {
        Console.WriteLine($"Department: {item.DepartmentName}, Total Salary: {item.TotalSalary}");
    }

    Console.WriteLine($"EF Core Execution Time: {stopwatch.ElapsedMilliseconds} ms");
}

// same function with dapper 
public void GetFinancialReportDapper()
{
    var stopwatch = Stopwatch.StartNew();

    using (IDbConnection db = new SqliteConnection(_connectionString))
    {
        var sql = @"
            SELECT d.DepartmentName,
                   SUM(e.Salary) AS TotalSalary
            FROM Departments d
            JOIN Employees e ON d.DepartmentId = e.DepartmentId
            JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
            JOIN Projects p ON ep.ProjectId = p.ProjectId
            GROUP BY d.DepartmentName";

        var results = db.Query(sql);

        stopwatch.Stop();

        Console.WriteLine("\nFinancial Report (Dapper):");
        foreach (var result in results)
        {
            Console.WriteLine($"Department: {result.DepartmentName}, Total Salary: {result.TotalSalary}");
        }

        Console.WriteLine($"Dapper Execution Time: {stopwatch.ElapsedMilliseconds} ms");
    }
}
}