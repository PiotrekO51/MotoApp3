namespace MotoApp3.Repositories;
using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

public class SqlRepository<T> :IRepository<T> where T : class, IEntity, new()
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    public SqlRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }
    
    public IEnumerable<T>GetAll()
    {
        return _dbSet.ToList(); 
    }
    public int GetNumberId(string txt)
    {
        int i = _dbSet.Count();
        Console.WriteLine($"długość {txt} = {i}");
        return i;

    }
    public T? GetById(int id)
    {
        return _dbSet.Single(item => item.Id == id);
    }
    public void Add(T item)
    {
        _dbSet.Add(item);
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}

