using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hunty.Chat.Back.Database.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(object id);
        Task<T> GetAsync(object id);
        Task<List<T>> GetAllAsync();
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> filter);
    }
}
