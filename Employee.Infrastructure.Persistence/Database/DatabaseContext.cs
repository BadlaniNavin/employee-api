using Employee.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Persistence.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
    {        
    }    

    public DbSet<EmployeeEntity> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        
    }
}
