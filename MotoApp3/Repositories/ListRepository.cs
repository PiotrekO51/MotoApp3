using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

namespace MotoApp3.Repositories;

public class ListRepository<T>
    where T : class, IEntity, new()

{
    protected List<T> _items = new();

    public void Add(T item)
    {
        item.Id = _items.Count + 1;
        _items.Add(item);
    }
    public IEnumerable<T> GetAll()
    {
        return _items.ToList();
    }
    public int GetNumberId(string txt)
    {
        int i = _items.Count();
        Console.WriteLine($"Długość {txt} = {i}");
        return i;

    }
    public T GetById(int id)
    {

        return _items.Single(item => item.Id == id);
    }

    public void Remove(T item)
    {
        _items.Remove(item);
    }
    public void Save()
    {
        
        //Save nie jest potrzebne w zapisie do listy
    }

}
