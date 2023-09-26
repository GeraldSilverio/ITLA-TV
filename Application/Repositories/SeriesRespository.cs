using Application.Interfaces.Repositories;
using Database.Context;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories
{
    public class SeriesRespository : BaseRepository<Series>, ISeriesRepository
    {
        private readonly ItlaStreamContext _dbContext;
        public SeriesRespository(ItlaStreamContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<Series> GetSerieByName(string name)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Name == name);

            return serie;
        }
    }
}
