namespace MotoApp3.Repositories;
using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

//public delegate void ItemAdded<in T>(T item);
public class SqlRepository<T> :IRepository<T> where T : class, IEntity, new()
{ 

  
    private readonly DbContext _dbContext;
    private readonly DbSet<T> _dbSet;
    private event Action <T>_itemAddedCallback;
    public event EventHandler<T>? ItemAded;
    public event EventHandler<T>? ItemDeleted;

    public SqlRepository(DbContext dbContext, Action<T>? itemAddedCallback = null)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
        _itemAddedCallback = itemAddedCallback;
    }

   

    public IEnumerable<T>GetAll()
    {
        return _dbSet.ToList(); 
    }
    public int GetNumberId(string txt)
    {
        int i = _dbSet.Count();
        Console.WriteLine($"Długość {txt} = {i}\n");
        return i;

    }
    public T? GetById(int id)
    {
        return _dbSet.Single(item => item.Id == id);
    }
    public void Add(T item)
    {
        _dbSet.Add(item);
        _itemAddedCallback?.Invoke(item);
        ItemAded?.Invoke(this, item);  
    }
    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }
    public void Save()
    {
        _dbContext.SaveChanges();
    }

    public void InsertItem(int index, T item)
    {
        throw new NotImplementedException();
    }
}

