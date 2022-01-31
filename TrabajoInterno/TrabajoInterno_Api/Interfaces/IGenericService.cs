using System.Collections.Generic;
using System.Threading.Tasks;

namespace TrabajoInterno_Api.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(int id);
    }
}
