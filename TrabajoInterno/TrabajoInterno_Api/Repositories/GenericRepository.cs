using Microsoft.EntityFrameworkCore;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Interfaces;

namespace TrabajoInterno_Api.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly MySqlDbContext mySqlDbContext;

        public GenericRepository(MySqlDbContext mySqlDbContext)
        {
            this.mySqlDbContext = mySqlDbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                return false;

            mySqlDbContext.Set<TEntity>().Remove(entity);
            await mySqlDbContext.SaveChangesAsync();
            return  true;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await mySqlDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetById(int id)
        {
            return await mySqlDbContext.Set<TEntity>().FindAsync(keyValues: id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            mySqlDbContext.Set<TEntity>().Add(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            mySqlDbContext.Set<TEntity>().Update(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
