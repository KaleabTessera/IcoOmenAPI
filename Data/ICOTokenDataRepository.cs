using ICOAppApi.Model;
using Microsoft.Extensions.Options;

namespace ICOAppApi.Data
{
    public class ICOTokenDataRepository : ICORepository<Datum>
    {
        public ICOTokenDataRepository(IOptions<Settings> settings) : base(settings)
        {
        }
    }

}
