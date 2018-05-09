using ICOAppApi.Model;
using Microsoft.Extensions.Options;

namespace ICOAppApi.Data
{
    public class ICOPredictionVCRepository : ICORepository<Hit>
    {
        public ICOPredictionVCRepository(IOptions<Settings> settings) : base(settings)
        {
        }
    }

}
