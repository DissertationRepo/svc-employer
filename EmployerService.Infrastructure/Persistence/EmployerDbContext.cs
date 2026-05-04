using EmployerService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployerService.Infrastructure.Persistence;

public sealed class EmployerDbContext : DbContext
{
    public EmployerDbContext(DbContextOptions<EmployerDbContext> options)
        : base(options)
    {
    }

    public DbSet<EmployerEntity> Employers => Set<EmployerEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployerDbContext).Assembly);
    }
}
