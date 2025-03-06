namespace MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

public class MotoAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<BusinesPartner> BusinesPartners => Set<BusinesPartner>();
    public DbSet<Manager> Managers => Set<Manager>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageMotoApp3");
    }
}

