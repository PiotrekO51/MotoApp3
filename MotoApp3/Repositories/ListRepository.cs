

using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

namespace MotoApp3.Repositories;

class ListRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly List<T> _items = new();
    private readonly Action<T>? _itemAdedCallback;
    public event EventHandler<T?>? ItemAded;
    public event EventHandler<T>? ItemDeleted;

    public ListRepository(Action<T>? itemAdedCalback = null )
    {
        _itemAdedCallback = itemAdedCalback;
     
    }

    

    public T? GetById(int id)
    {
        return _items.Single(item => item.Id == id);
    }
    public IEnumerable<T> GetAll() => _items.ToList();
    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
        _itemAdedCallback?.Invoke(item);
        ItemAded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
        ItemDeleted?.Invoke(this, item);
    }

    public void Save()
    {
       
    }
    public int GetNumberId(string txt)
    {
        int i = _items.Count();
        Console.WriteLine($"Długość {txt} = {i}\n");
        return i;
    }
    public void InsertItem(int index, T item)
    {
        _items.Insert(index, item);
        ItemAded?.Invoke(this, item);
    }
}
