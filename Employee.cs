// Employee.cs
public class Employee
{
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public decimal Salary { get; set; }
    public double PerformanceRating { get; set; } // New property for task 4 
    public int DepartmentId { get; set; }
    public Department Department { get; set; } // Many-to-one relationship with Department (each department has many employees)
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } // Many-to-many relationship with Project (each project has many emplyess and each emplyee has many projects)
}