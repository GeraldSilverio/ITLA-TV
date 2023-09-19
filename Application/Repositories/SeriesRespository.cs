using Database.Context;
using Database.Models;

namespace Application.Repositories
{
    public class SeriesRespository : BaseRepository<Series>
    {
        public SeriesRespository(ItlaStreamContext dbContext) : base(dbContext)
        {

        }


    }
}
