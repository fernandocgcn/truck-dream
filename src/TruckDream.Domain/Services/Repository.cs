using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TruckDream.Domain.Services
{
    public interface Repository
    {
        Task<List<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class;
        ValueTask<TEntity> GetByIdAsync<TEntity>(object id) where TEntity : class;
        void InsertAsync<TEntity>(TEntity entity) where TEntity : class;
        void Attach<TEntity>(TEntity entity) where TEntity : class;
        void DeleteById<TEntity>(object id) where TEntity : class;
        void Update<TEntity>(TEntity entity) where TEntity : class;
        Task<int> CommitAsync();
    }
}
