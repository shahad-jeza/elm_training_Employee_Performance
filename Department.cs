// Department.cs
public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public ICollection<Employee> Employees { get; set; } // One-to-many relationship with Employee (each emplyee belongs to one dpartment)
}

