using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using TrabajoInterno_Api.Common;
using TrabajoInterno_Api.Data;
using TrabajoInterno_Api.Interfaces;
using TrabajoInterno_Api.Models;

namespace TrabajoInterno_Api.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly MySqlDbContext mySqlDbContext;
        

        public GenericRepository(MySqlDbContext mySqlDbContext)
        {
            this.mySqlDbContext = mySqlDbContext;
        }

        public GenericRepository()
        {

        }

        public virtual async Task<bool> Delete(string id)
        {
            var entity = await GetById(id);

            if (entity == null)
                return false;

            mySqlDbContext.Set<TEntity>().Remove(entity);
            await mySqlDbContext.SaveChangesAsync();
            return  true;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await mySqlDbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity?> GetById(string id)
        {
            return await mySqlDbContext.Set<TEntity>().FindAsync(keyValues: Convert.ToInt32(id));
        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            mySqlDbContext.Set<TEntity>().Add(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            mySqlDbContext.Set<TEntity>().Update(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }
    }
}
