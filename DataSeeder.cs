using System;
using System.Linq;

// adding dummy data to see the effect of queries
public class DataSeeder
{
    private readonly AppDbContext _context;

    public DataSeeder(AppDbContext context)
    {
        _context = context;
    }

public void SeedData()
{
    if (_context.Employees.Any())
    {
        Console.WriteLine("Database already seeded.");
        return;
    }

    // Add Departments
    var department1 = new Department { DepartmentName = "Engineering" };
    var department2 = new Department { DepartmentName = "Marketing" };
    _context.Departments.AddRange(department1, department2);
    _context.SaveChanges();

    // Add Employees with Performance Ratings
    var employee1 = new Employee { EmployeeName = "John Doe", Salary = 60000, PerformanceRating = 1.0, DepartmentId = department1.DepartmentId };
    var employee2 = new Employee { EmployeeName = "Jane Smith", Salary = 55000, PerformanceRating = 0.9, DepartmentId = department1.DepartmentId };
    var employee3 = new Employee { EmployeeName = "Alice Johnson", Salary = 50000, PerformanceRating = 0.8, DepartmentId = department2.DepartmentId };
    _context.Employees.AddRange(employee1, employee2, employee3);
    _context.SaveChanges();

    // Add Projects
    var project1 = new Project { ProjectName = "Project A", ProjectDeadline = DateTime.Now.AddMonths(-5) };
    var project2 = new Project { ProjectName = "Project B", ProjectDeadline = DateTime.Now.AddMonths(-4)};
    var project3 = new Project { ProjectName = "Project C", ProjectDeadline = DateTime.Now.AddMonths(-3) };
    var project4 = new Project { ProjectName = "Project D", ProjectDeadline = DateTime.Now.AddMonths(-2)};
    _context.Projects.AddRange(project1, project2, project3, project4);
    _context.SaveChanges();

    // Assign Employees to Projects
    _context.EmployeeProjects.AddRange(
        new EmployeeProject { EmployeeId = employee1.EmployeeId, ProjectId = project1.ProjectId },
        new EmployeeProject { EmployeeId = employee1.EmployeeId, ProjectId = project2.ProjectId },
        new EmployeeProject { EmployeeId = employee1.EmployeeId, ProjectId = project3.ProjectId },
        new EmployeeProject { EmployeeId = employee1.EmployeeId, ProjectId = project4.ProjectId },
        new EmployeeProject { EmployeeId = employee2.EmployeeId, ProjectId = project1.ProjectId },
        new EmployeeProject { EmployeeId = employee2.EmployeeId, ProjectId = project3.ProjectId },
        new EmployeeProject { EmployeeId = employee3.EmployeeId, ProjectId = project2.ProjectId }
    );
    _context.SaveChanges();

    Console.WriteLine("Database seeded successfully.");
}
}