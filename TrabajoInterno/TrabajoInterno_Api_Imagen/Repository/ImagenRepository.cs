using MongoDB.Driver;
using TrabajoInterno_Api_Imagen.Data;
using TrabajoInterno_Api_Imagen.Interfaces;
using TrabajoInterno_Api_Imagen.Models;

namespace TrabajoInterno_Api_Imagen.Repository
{
    public class ImagenRepository : IImagenRepository
    {
        protected readonly IMongoCollection<Imagen> mongoDbContext;

        public ImagenRepository(IConnectionMdbSettings mongoDbContext) :  base()
        {
            var cliente = new MongoClient(mongoDbContext.Server);
            var database = cliente.GetDatabase(mongoDbContext.DataBase);
            this.mongoDbContext = database.GetCollection<Imagen>(mongoDbContext.Collection);
        }

        public async Task<int> DeleteImagenByIdPersona(int idPersona)
        {
            var result = await mongoDbContext.DeleteManyAsync(d => d.Id_Persona == idPersona);
            return (int)result.DeletedCount;
        }

        public async Task<bool> Delete(string id) => await mongoDbContext.DeleteOneAsync(i => i.Id == id.ToString()) != null;

        public async Task<IEnumerable<Imagen>> GetAll() => await mongoDbContext.Find(d => true).ToListAsync();

        public async Task<Imagen?> GetById(string id) => await mongoDbContext.Find(d => d.Id == id.ToString()).SingleAsync();

        public async Task<Imagen> Insert(Imagen imagen)
        {
            await mongoDbContext.InsertOneAsync(imagen);
            return mongoDbContext.Find(d => true).ToList().Last();
        }

        public async Task<Imagen> Update(Imagen imagen)
        {
            await mongoDbContext.ReplaceOneAsync(i => i.Id == imagen.Id, imagen);
            return await mongoDbContext.Find(i => i.Id == imagen.Id).SingleAsync();
        }
    }
}
