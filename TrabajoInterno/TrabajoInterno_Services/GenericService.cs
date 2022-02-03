using TrabajoInterno_Abstraccion;

namespace TrabajoInterno_Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        protected readonly IGenericRepository<TEntity> genericRepository;

        public GenericService(IGenericRepository<TEntity> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public virtual async Task<bool> Delete(string id) => await genericRepository.Delete(id);

        public async Task<IEnumerable<TEntity>> GetAll() => await genericRepository.GetAll();

        public async Task<TEntity?> GetById(string id) => await genericRepository.GetById(id);

        public async Task<TEntity> Insert(TEntity entity) => await genericRepository.Insert(entity);

        public async Task<TEntity> Update(TEntity entity) => await genericRepository.Update(entity);

    }
}
