using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Querying.Referrals.Services.Repository.Base
{
    /// <summary>
    /// The base repository abstract class.
    /// </summary>
    /// <typeparam name="TC">DbContext</typeparam>
    /// <typeparam name="T">Class</typeparam>
    public abstract class Repository<TC, T> : IDisposable, IRepository<T> where T : class where TC : DbContext
    {
        private bool _disposed;

        public TC Context { get; set; }

        /// <summary>
        /// Repository constructor. Pass your DbContext here.
        /// </summary>
        /// <param name="context"></param>
        protected Repository(TC context)
        {
            try
            {
                Context = context;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/Repository: " + e.Message, e);
            }
        }

        /// <summary>
        /// Enumerates the server query. 
        /// </summary>
        public virtual void Load()
        {
            try
            {
                Context.Set<T>().Load();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/Load: " + e.Message, e);
            }
        }

        /// <summary>
        /// Enumerates the server query asynchronously.
        /// </summary>
        /// <returns></returns>
        public virtual async Task LoadAsync()
        {
            try
            {
                await Context.Set<T>().LoadAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/LoadAsync: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a DbSet of TEntity instance.
        /// </summary>
        /// <returns>IQueryable of T</returns>
        public virtual IQueryable<T> GetAllToIQuerable()
        {
            try
            {
                var query = Context.Set<T>();
                return query;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetAllToIQuerable: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a List of T.
        /// </summary>
        /// <returns>List of T</returns>
        public virtual List<T> GetAllToList()
        {
            try
            {
                var queryToList = Context.Set<T>().ToList();
                return queryToList;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetAllToList: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a List of T asynchronously.
        /// </summary>
        /// <returns>List of T</returns>
        public virtual async Task<List<T>> GetAllToListAsync()
        {
            try
            {
                var queryToList = await Context.Set<T>().ToListAsync();
                return queryToList;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetAllToListAsync: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a DbSet of TEntity instance filtered using the predicate parameter.
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>IQueryable of T</returns>
        public virtual IQueryable<T> GetFilteredToIQuerable(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var query = Context.Set<T>().Where(predicate);
                return query;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetFilteredToIQuerable: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a List of T filtered using the predicate parameter.
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of T</returns>
        public virtual List<T> GetFilteredToList(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var query = Context.Set<T>().Where(predicate).ToList();
                return query;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetFilteredToList: " + e.Message, e);
            }
        }

        /// <summary>
        /// Returns a List of T asynchronously filtered using the predicate parameter.
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>List of T</returns>
        public virtual async Task<List<T>> GetFilteredToListAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var queryToList = await Context.Set<T>().Where(predicate).ToListAsync();
                return queryToList;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/GetFilteredToListAsync: " + e.Message, e);
            }
        }

        /// <summary>
        /// Adds the entity to the related entities model. Must save the changes later to update the db.
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void Add(T entity)
        {
            try
            {
                Context.Set<T>().Add(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/Add: " + e.Message, e);
            }
        }

        /// <summary>
        /// Adds or updates the entity in the related entities model. Must save the changes later to update the db.
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void AddOrUpdate(T entity)
        {
            try
            {
                Context.Set<T>().AddOrUpdate(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/AddOrUpdate: " + e.Message, e);
            }
        }

        /// <summary>
        /// Adds or updates entities from the list in the related entities model. Must save the changes later to update the db.
        /// </summary>
        /// <param name="entitiesRange">IEnumerable of TEntity</param>
        public virtual void AddOrUpdateRange(IEnumerable<T> entitiesRange)
        {
            try
            {
                var enumerable = entitiesRange as IList<T> ?? entitiesRange.ToList();

                foreach (var entity in enumerable)
                {
                    //Context.Set<T>().Attach(entity);
                    Context.Set<T>().AddOrUpdate(entity);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/AddOrUpdateRange: " + e.Message, e);
            }
        }

        /// <summary>
        /// Adds a range of entities to the related entities model. Must save the changes later to update the db.
        /// </summary>
        /// <param name="entitiesRange">IEnumerable of TEntity</param>
        public virtual void AddRange(IEnumerable<T> entitiesRange)
        {
            try
            {
                Context.Set<T>().AddRange(entitiesRange);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/AddRange: " + e.Message, e);
            }
        }

        /// <summary>
        /// Removes an entity from the related entities model.
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void Remove(T entity)
        {
            try
            {
                Context.Set<T>().Attach(entity);

                Context.Set<T>().Remove(entity);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/Remove: " + e.Message, e);
            }
        }

        /// <summary>
        /// Removes a range of entities from the related entities model.
        /// </summary>
        /// <param name="entitiesRange">IEnumerable of TEntity</param>
        public virtual void RemoveRange(IEnumerable<T> entitiesRange)
        {
            try
            {
                var enumerable = entitiesRange as IList<T> ?? entitiesRange.ToList();

                foreach (var entity in enumerable)
                {
                    Context.Set<T>().Attach(entity);
                }

                Context.Set<T>().RemoveRange(enumerable);
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/RemoveRange: " + e.Message, e);
            }
        }

        /// <summary>
        /// Changes the entity's model status to Modified.
        /// </summary>
        /// <param name="entity">TEntity</param>
        public virtual void SetEntityStateToModified(T entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/SetEntityStateToModified: " + e.Message, e);
            }
        }

        /// <summary>
        /// Reflects/Saves any entity's changes to the db.
        /// </summary>
        public virtual void SaveChanges()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/SaveChanges: " + e.Message, e);
            }
        }

        /// <summary>
        /// Reflects/Saves asynchronously any entity's changes to the db.
        /// </summary>
        /// <returns></returns>
        public virtual async Task SaveChangesAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("Method: Querying.Referrals.Services.Repository.Base/Repository/SaveChangesAsync: " + e.Message, e);
            }
        }

        /// <summary>
        /// Disposes the Context.
        /// </summary>
        /// <param name="disposing">bool</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        /// <summary>
        /// Sets the local members and requests from the CLR to do not call the finalizer for the object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
