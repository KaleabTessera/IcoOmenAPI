using System;
using System.Threading.Tasks;
using ICOAppApi.Interfaces;
using ICOAppApi.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ICOAppApi.Data
{
    public class ICORepository<T> : IRepository<T>
    {
        private readonly ICOContext<T> _context = null;

        public ICORepository(IOptions<Settings> settings)
        {
            _context = new ICOContext<T>(settings);
        }

        public async Task Insert(T entity, string collection){
            try
            {
                IMongoCollection<T> mongoCollection = _context.GetCollection(collection);
                await mongoCollection.InsertOneAsync(entity);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task Delete(T entity, string collection)
        {
            throw new NotImplementedException();
        }

        // void IRepository<T> Insert(T entity, string collection)
        // {
        //     throw new System.NotImplementedException();
        // }

        // void IRepository<T> Delete(T entity)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}