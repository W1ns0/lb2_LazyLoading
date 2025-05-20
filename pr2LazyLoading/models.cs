using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

public class ApplicationContext : DbContext
{
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()        // подключение lazy loading
            .UseNpgsql("Host=localhost;Port=5432;Database=lb2_Company;Username=postgres;Password=1111;");
    }

}
public class Department
{
    public int id { get; set; }
    public string? name { get; set; }

    public virtual List<Position> Positions { get; set; } = new();
}

public class Position
{
    public int id { get; set; }
    public string? title { get; set; }
    public int DepartmentId { get; set; }

    public virtual Department? Department { get; set; }
    public virtual List<Employee> Employees { get; set; } = new();
}

public class Employee
{
    public int id { get; set; }
    public string? name { get; set; }
    public int PositionId { get; set; }

    public virtual Position? Position { get; set; }
}

