using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using ICOAppApi.Interfaces;
using ICOAppApi.Model;
using MongoDB.Bson;

namespace ICOAppApi.Data
{
    public class ICORepository : InterfaceICORepository
    {
        private readonly ICOContext _context = null;

        public ICORepository(IOptions<Settings> settings)
        {
            _context = new ICOContext(settings);
        }

        // public async Task<IEnumerable<ICO>> GetAllICOs()
        // {
        //     try
        //     {
        //         return await _context.Notes.Find(_ => true).ToListAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        // query after internal or internal id
        //
        // public async Task<ICO> GetICO(string id)
        // {
        //     try
        //     {
        //         ObjectId internalId = GetInternalId(id);
        //         return await _context.Notes
        //                         .Find(Ico => Ico.Id == id || Ico.InternalId == internalId)
        //                         .FirstOrDefaultAsync();
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddICOStats(Ico item)
        {
            try
            {
                await _context.ICOStats.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddICODrops(ICODrops item)
        {
            try
            {
                await _context.ICODrops.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // public async Task<bool> RemoveICO(string id)
        // {
        //     try
        //     {
        //         DeleteResult actionResult = await _context.Notes.DeleteOneAsync(
        //              Builders<ICO>.Filter.Eq("Id", id));

        //         return actionResult.IsAcknowledged 
        //             && actionResult.DeletedCount > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        // public async Task<bool> UpdateICO(string id, string body)
        // {
        //     var filter = Builders<ICO>.Filter.Eq(s => s.Id, id);
        //     var update = Builders<ICO>.Update
        //                     .Set(s => s.Body, body)
        //                     .CurrentDate(s => s.UpdatedOn);

        //     try
        //     {
        //         UpdateResult actionResult = await _context.Notes.UpdateOneAsync(filter, update);

        //         return actionResult.IsAcknowledged
        //             && actionResult.ModifiedCount > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        // public async Task<bool> UpdateICO(string id, ICO item)
        // {
        //     try
        //     {
        //         ReplaceOneResult actionResult = await _context.Notes
        //                                         .ReplaceOneAsync(n => n.Id.Equals(id)
        //                                                         , item
        //                                                         , new UpdateOptions { IsUpsert = true });
        //         return actionResult.IsAcknowledged
        //             && actionResult.ModifiedCount > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        // Demo function - full document update
        // public async Task<bool> UpdateICODocument(string id, string body)
        // {
        //     var item = await GetICO(id) ?? new ICO();
        //     item.Body = body;
        //     item.UpdatedOn = DateTime.Now;

        //     return await UpdateICO(id, item);
        // }

        // public async Task<bool> RemoveAllICOs()
        // {
        //     try
        //     {
        //         DeleteResult actionResult = await _context.Notes.DeleteManyAsync(new BsonDocument());

        //         return actionResult.IsAcknowledged
        //             && actionResult.DeletedCount > 0;
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }

        // it creates a compound index (first using UserId, and then Body)
        // MongoDb automatically detects if the index already exists - in this case it just returns the index details
        // public async Task<string> CreateIndex()
        // {
        //     try
        //     {
        //         return await _context.Notes.Indexes
        //                                    .CreateOneAsync(Builders<ICO>
        //                                                         .IndexKeys
        //                                                         .Ascending(item => item.UserId)
        //                                                         .Ascending(item => item.Body));
        //     }
        //     catch (Exception ex)
        //     {
        //         // log or manage the exception
        //         throw ex;
        //     }
        // }
    }
}
