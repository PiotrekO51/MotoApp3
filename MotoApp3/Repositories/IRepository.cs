﻿using Microsoft.EntityFrameworkCore;
using MotoApp3.Entities;

namespace MotoApp3.Repositories;

public interface IRepository<T>: IReadRepository<T> , IWriteRepository<T> 
    where T: class, IEntity, new()
{
    public event EventHandler<T?>? ItemAded;
    public event EventHandler<T>? ItemDeleted;
}
