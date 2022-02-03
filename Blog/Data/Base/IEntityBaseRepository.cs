using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {

        Task<IEnumerable<T>> GetAllAsync();

        // przekazywanie więcej niż jednego parametru, przekazywanie całych propsów
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T,object>>[] includeProperties);

        Task<T> GetByIdAsync(int id);

        Task AddAsync(int id, T entity);

        Task UpdateAsync(int id, T entity);


        Task DeleteAsync(int id);

    }
}
