﻿using Play.Catalog.Entities;

namespace Play.Catalog.Repository
{
    public interface IRepository<T>  where T : IEntity
    {
        Task CreateAsync(T entity);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(T entity);
    }
}