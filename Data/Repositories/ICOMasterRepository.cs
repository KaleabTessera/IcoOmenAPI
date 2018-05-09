using ICOAppApi.Model;
using Microsoft.Extensions.Options;

namespace ICOAppApi.Data
{
    public class ICOMasterRepository : ICORepository<ICOMaster>
    {
        public ICOMasterRepository(IOptions<Settings> settings) : base(settings)
        {
        }
    }

}
