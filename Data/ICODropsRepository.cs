using ICOAppApi.Model;
using Microsoft.Extensions.Options;

namespace ICOAppApi.Data
{
    public class ICODropsRepository : ICORepository<ICODrops>
    {
        public ICODropsRepository(IOptions<Settings> settings) : base(settings)
        {
        }
    }

}
