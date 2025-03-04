using MotoApp3.Entities;

namespace MotoApp3.Repositories;

public  interface IWriteRepository<in T> where T : class, IEntity
{
    void Add(T item);

    void Remove(T item);

}
