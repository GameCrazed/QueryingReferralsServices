using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Querying.Referrals.Services.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        void Load();
        Task LoadAsync();
        IQueryable<T> GetAllToIQuerable();
        List<T> GetAllToList();
        Task<List<T>> GetAllToListAsync();
        IQueryable<T> GetFilteredToIQuerable(Expression<Func<T, bool>> predicate);
        List<T> GetFilteredToList(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetFilteredToListAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddOrUpdate(T entity);
        void AddOrUpdateRange(IEnumerable<T> entitiesRange);
        void AddRange(IEnumerable<T> entitiesRange);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entitiesRange);
        void SetEntityStateToModified(T entity);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
