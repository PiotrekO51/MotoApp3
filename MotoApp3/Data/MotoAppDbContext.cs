namespace MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using MotoApp3.Entities;

public class MotoAppDbContext : DbContext
{
    public MotoAppDbContext(DbContextOptions<MotoAppDbContext> options)
        : base(options)
    {
    }


    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<BusinesPartner> BusinesPartners => Set<BusinesPartner>();
    public DbSet<Manager> Managers => Set<Manager>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseInMemoryDatabase("StorageMotoApp3");
    }


}

