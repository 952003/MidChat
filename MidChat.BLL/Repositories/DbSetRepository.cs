using Microsoft.EntityFrameworkCore;
using MidChat.BLL.Interfeces;
using MidChat.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Repositories
{
    public abstract class DbSetRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> dbSet;

        protected readonly DbContext dbContext;

        public DbSetRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
                dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> Get(int id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual void Update(TEntity entity)
        {
            dbContext.ChangeTracker.Clear();
            dbSet.Update(entity);
        }
    }
}
