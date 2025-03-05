namespace MotoApp3.Data;
using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;


public class MotoAppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<BusinesPartner> BusinesPartners => Set<BusinesPartner>();

    protected override void OnConfiguring(DbContextOptionsBuilder opcjeBudowania)//optionsBuilder
    {
        base.OnConfiguring(opcjeBudowania);
        opcjeBudowania.UseInMemoryDatabase("StorageMotoApp3");
    }


}

