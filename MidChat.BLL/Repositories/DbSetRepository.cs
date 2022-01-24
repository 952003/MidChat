using EntitiesDB.EF;
using Microsoft.EntityFrameworkCore;
using MidChat.BLL.Interfeces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Repositories
{
    public class DbSetRepository<T> : IRepository<T> where T :class
    {
        protected readonly DbSet<T> dbSet;

        protected readonly MainDbContext dbContext;

        public DbSetRepository(MainDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public virtual async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public virtual async Task Delete(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
                dbSet.Remove(entity);
        }

        public virtual async Task<T> Get(int id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> Find(Func<T, Boolean> entity)
        {
            return (IQueryable<T>)dbSet.Where(entity).ToList();
        }
    }
}
