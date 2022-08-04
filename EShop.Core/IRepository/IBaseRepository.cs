using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EShop.Core.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        ValueTask<EntityEntry<T>> AddAsync(T t);
        Task AddRangeAsync(IEnumerable<T> entities);
        ValueTask<T> GetByIdAsync(int id);
        void Remove(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
    }
}
