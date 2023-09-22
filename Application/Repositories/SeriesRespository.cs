using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;

namespace Application.Repositories
{
    public class SeriesRespository : BaseRepository<Series>, ISeriesRepository
    {
        public SeriesRespository(ItlaStreamContext dbContext) : base(dbContext)
        {


        }


    }
}
