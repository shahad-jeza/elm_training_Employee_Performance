// Project.cs
public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime ProjectDeadline { get; set; }
    public ICollection<EmployeeProject> EmployeeProjects { get; set; } // Many-to-many relationship with Employee
}