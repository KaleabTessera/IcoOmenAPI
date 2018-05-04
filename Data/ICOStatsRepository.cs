using ICOAppApi.Model;
using Microsoft.Extensions.Options;

namespace ICOAppApi.Data
{
    public class ICOStatsRepository : ICORepository<ICOStats>
    {
        public ICOStatsRepository(IOptions<Settings> settings) : base(settings)
        {
        }
    }

}
