using MongoDB.Driver;
using TrabajoInterno_Abstraccion;
using TrabajoInterno_DataAccess;
using TrabajoInterno_Entities;

namespace TrabajoInterno_Repository
{
    public class ImagenRepository : GenericRepository<Imagen>, IImagenRepository
    {
        protected readonly IMongoCollection<Imagen> mongoDbContext;

        public ImagenRepository(IConnectionMdbSettings mongoDbContext) :  base()
        {
            var cliente = new MongoClient(mongoDbContext.Server);
            var database = cliente.GetDatabase(mongoDbContext.DataBase);
            this.mongoDbContext = database.GetCollection<Imagen>(mongoDbContext.Collection);
        }

        public async Task<bool> DeleteImagenByIdPersona(int idPersona) 
            => await mongoDbContext.DeleteManyAsync(d => d.Id_Persona == idPersona) != null;


        public override async Task<bool> Delete(string id) => await mongoDbContext.DeleteOneAsync(i => i.Id == id.ToString()) != null;

        public override async Task<IEnumerable<Imagen>> GetAll() => await mongoDbContext.Find(d => true).ToListAsync();

        public override async Task<Imagen?> GetById(string id) => await mongoDbContext.Find(d => d.Id == id.ToString()).SingleAsync();

        public override async Task<Imagen> Insert(Imagen imagen)
        {
            await mongoDbContext.InsertOneAsync(imagen);
            return mongoDbContext.Find(d => true).ToList().Last();
        }

        public override async Task<Imagen> Update(Imagen imagen)
        {
            await mongoDbContext.ReplaceOneAsync(i => i.Id == imagen.Id, imagen);
            return await mongoDbContext.Find(i => i.Id == imagen.Id).SingleAsync();
        }
    }
}
