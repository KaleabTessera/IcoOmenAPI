using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ICOAppApi.Model;

namespace ICOAppApi.Data
{
    public class ICOContext
    {
        private readonly IMongoDatabase _database = null;

        public ICOContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Ico> ICOStats
        {
            get
            {
                return _database.GetCollection<Ico>("ICOStats");
            }
        }

        public IMongoCollection<ICODrops> ICODrops
        {
            get
            {
                return _database.GetCollection<ICODrops>("ICODrops");
            }
        }
    }
}
