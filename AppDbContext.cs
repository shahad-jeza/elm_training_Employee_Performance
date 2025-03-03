using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Add this constructor
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship between Employee and Project
        modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId }); // Composite key

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);
    }
}