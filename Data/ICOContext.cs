using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ICOAppApi.Model;

namespace ICOAppApi.Data
{
    public class ICOContext<T>
    {
        private readonly IMongoDatabase _database = null;

        public ICOContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> GetCollection(string collection)
        {
            {
                return _database.GetCollection<T>(collection);
            }
        }
    }
}
