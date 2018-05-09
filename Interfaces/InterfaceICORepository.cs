using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICOAppApi.Model;

namespace ICOAppApi.Interfaces
{
    // public interface InterfaceICORepository
    // {
    //     // Task<IEnumerable<ICO>> GetAllICOs();
    //     // Task<ICO> GetICO(string id);

    //     // add new Ico document
    //     // Task AddICO(ICO item);
    //     //Task AddICO(Ico item);

    //     // remove a single document / Ico
    //     // Task<bool> RemoveICO(string id);

    //     // // update just a single document / Ico
    //     // Task<bool> UpdateICO(string id, string body);

    //     // // demo interface - full document update
    //     // Task<bool> UpdateICODocument(string id, string body);

    //     // // should be used with high cautious, only in relation with demo setup
    //     // Task<bool> RemoveAllICOs();

    //     // // creates a sample index
    //     // Task<string> CreateIndex();

    //     Task AddICOStats(Ico item);
    //     Task AddICODrops(ICODrops item);
    // }
     public interface IRepository<T>
    {
        Task Insert(T entity, string collection, string name);
        Task Delete(T entity, string collection);
        //IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        // IQueryable<T> GetAll();
        // T GetById(int id);
    }
}
