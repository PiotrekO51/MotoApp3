using MotoApp3.Entities;

namespace MotoApp3.Repositories;

public interface IReadRepository<out T> where T : class, IEntity
{
 IEnumerable<T> GetAll();

int GetNumberId(string txt);

T? GetById(int id);
}
