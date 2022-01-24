using EntitiesDB.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task Add(TEntity entity);

        Task<TEntity> Get(int id);

        IQueryable<TEntity> GetAll();

        void Update(TEntity entity);

        Task Delete(int id);
    }
}
