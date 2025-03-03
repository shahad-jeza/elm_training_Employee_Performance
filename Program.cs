using System;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the database context
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=EmployeePerformance.db") // SQLite database file
            .Options;

        using (var context = new AppDbContext(options))
        {
            // Seed the database with sample data using the DataSeeder class
            var seeder = new DataSeeder(context);
            seeder.SeedData();

            // Run Task 2: LINQ Query to find employees with more than 3 projects in the last 6 months
            var employeeService = new EmployeeService(context);
            employeeService.FindEmployeesWithMoreThan3Projects();

            // Run Task 3: Use Dapper to retrieve employees and their projects
            Console.WriteLine("\nEmployees and their projects (using Dapper):");
            employeeService.GetEmployeesWithProjects();

          
            // // Run Task 4: Calculate employee bonuses using raw SQL
            // employeeService.CalculateEmployeeBonuses();

            // Run Task 4: Simulate a stored procedure to calculate bonuses
            employeeService.CalculateEmployeeBonuses();


            // Run Task 5: Compare EF Core and Dapper for financial reports
            // the functions implements stopwatch so the time will be ompuated 
            employeeService.GetFinancialReportEFCore();
            employeeService.GetFinancialReportDapper();
        }
    }
}