using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MidChat.BLL.Interfeces.BLLInterfeces.CRUDService
{
    public interface ICrudService<TEntity, TModel> where TEntity : class where TModel : class
    {
        Task CreateAsync(TModel model);

        Task CreateRangeAsync(IEnumerable<TModel> models);

        Task<TModel> GetAsync(int id);

        Task<IEnumerable<TModel>> GetAllAsync();

        Task UpdateAsync(TModel model);

        Task DeleteAsync(int id);

        Task DeleteRangeAsync(IEnumerable<int> ids);
    }
}
