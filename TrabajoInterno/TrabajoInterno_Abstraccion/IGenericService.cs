namespace TrabajoInterno_Abstraccion
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(string id);
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<bool> Delete(string id);
    }
}
