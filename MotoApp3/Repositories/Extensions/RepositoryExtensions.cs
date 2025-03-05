using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;
namespace MotoApp3.Repositories.Extensions;

public static class RepositoryExtensions
{
    public static void AddBatch<T>(this IRepository<T> repository, T[] items)
    where T : class, IEntity, new()
    {
        foreach (var emp in items)
        {
            repository.Add(emp);
        }
        repository.Save();
    }
}
