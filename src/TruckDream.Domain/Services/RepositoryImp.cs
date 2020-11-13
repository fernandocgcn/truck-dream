using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TruckDream.Domain.Services
{
    public class RepositoryImp : Repository
    {
        private readonly DbContext dbContext;

        public RepositoryImp(DbContext dbContext) 
            => this.dbContext = dbContext ?? 
                throw new ArgumentNullException(nameof(dbContext));

        public Task<List<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") where TEntity : class
        {
            IQueryable<TEntity> query = dbContext.Set<TEntity>();

            query = filter == null ? query : query.Where(filter);

            var includes = includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Array.ForEach(includes, item => query = query.Include(item));

            return orderBy == null ? 
                query.ToListAsync() : 
                orderBy(query).ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync<TEntity>(object id) 
            where TEntity : class => dbContext.Set<TEntity>().FindAsync(id);

        public void InsertAsync<TEntity>(TEntity entity) 
            where TEntity : class => dbContext.Set<TEntity>().AddAsync(entity);

        public void DeleteById<TEntity>(object id) where TEntity : class
        {
            var dbSet = dbContext.Set<TEntity>();
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = dbContext.Set<TEntity>();
            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Update(entity);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default) 
            => dbContext.SaveChangesAsync(cancellationToken);

        public void DetachAll()
            => dbContext?.ChangeTracker?.Entries()?.ToList()?
                .ForEach(entityEntry => entityEntry.State = EntityState.Detached);
    }
}
