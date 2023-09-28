using Application.Interfaces.Repositories;
using Application.ViewModels.SeriesViewModel;
using Database.Context;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class SerieGenderRepository : BaseRepository<SerieGender>, ISeriesGendersRepository
    {
        private readonly ItlaStreamContext _dbContext;
        public SerieGenderRepository(ItlaStreamContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ClearSerieGender(int idSerie)
        {
            var series = _dbContext.SerieGenders.Where(x => x.IdSerie == idSerie);

            foreach(var serie in series)
            {
                 _dbContext.Remove(serie);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
