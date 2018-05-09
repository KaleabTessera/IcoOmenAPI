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
        private readonly ICOContext<ICOMaster> _icoMaster = null;

        public ICORepository(IOptions<Settings> settings)
        {
            _context = new ICOContext<T>(settings);
            _icoMaster = new ICOContext<ICOMaster>(settings);
        }

        public async Task Insert(T entity, string collection, string name)
        {
            try
            {   
                name = name.ToLower().Replace(" ", "_");;
                IMongoCollection<T> mongoCollection = _context.GetCollection(collection);
                await mongoCollection.InsertOneAsync(entity);

                //COMasterRepository iCOMasterRepository = new ICOMasterRepository();

                IMongoCollection<ICOMaster> masterCollection = (IMongoCollection<ICOMaster>)_icoMaster.GetCollection("ICOMaster");
                if (masterCollection != null)
                {
                    ICOMaster icoMaster = masterCollection.Find(x => x.name == name).FirstOrDefault();

                    if (icoMaster == null)
                    {
                        ICOMaster elementToAdd = new ICOMaster
                        {
                            name = name
                        };
                        switch (collection)
                        {
                            case "ICODrops":
                                {
                                    ICODrops ele = (ICODrops)(object)entity;
                                    elementToAdd.ICODropsRef =  ele.InternalId;
                                    break;
                                }
                            case "ICOStats":
                                {
                                    ICOStats ele = (ICOStats)(object)entity;
                                    elementToAdd.ICOStatsRef =  ele.InternalId;
                                    break;
                                }
                            case "ICOTokenData":
                                {
                                    Datum ele = (Datum)(object)entity;
                                    elementToAdd.ICOTokenDataRef = ele.InternalId;
                                    break;
                                }
                            case "PredictionVC":
                                {
                                    Hit ele = (Hit)(object)entity;
                                    elementToAdd.PredictionVCRef = ele.InternalId;
                                    break;
                                }
                        }

                        masterCollection.InsertOne(elementToAdd);
                    }
                    else
                    {
                        Object update = null ;
                        switch (collection)
                        {
                            case "ICODrops":
                                {
                                    ICODrops ele = (ICODrops)(object)entity;
                                    update = Builders<ICOMaster>.Update.Set("ICODropsRef",  ele.InternalId);
                                    // icoMaster.ICODrops = new MongoDBRef(collection, ele.InternalId);
                                    break;
                                }
                            case "ICOStats":
                                {
                                    ICOStats ele = (ICOStats)(object)entity;
                                     update = Builders<ICOMaster>.Update.Set("ICOStatsRef",  ele.InternalId);
                                   // icoMaster.ICOStats = new MongoDBRef(collection, ele.InternalId);
                                    break;
                                }
                            case "ICOTokenData":
                                {
                                    Datum ele = (Datum)(object)entity;
                                    update = Builders<ICOMaster>.Update.Set("ICOTokenDataRef",  ele.InternalId);
                                    //icoMaster.ICOTokenData = new MongoDBRef(collection, ele.InternalId);
                                    break;
                                }
                            case "PredictionVC":
                                {
                                    Hit ele = (Hit)(object)entity;
                                     update = Builders<ICOMaster>.Update.Set("PredictionVCRef",  ele.InternalId);
                                   // icoMaster.ICODrops = new MongoDBRef(collection, ele.InternalId);
                                    break;
                                }
                        }
                        var filter = Builders<ICOMaster>.Filter.Eq("name", name);
                        //var update = Builders<ICOMaster>.Update.Set(x => x. Items.Single(p => p.Id.Equals(itemId)).Title, title);
                        masterCollection.UpdateOne(filter,(UpdateDefinition<ICOMaster>)update);
                    }
                }


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