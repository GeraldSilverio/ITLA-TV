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

        public List<SerieGender> GetSerieGendersByIdSerie(int idSerie)
        {
            var gender = _dbContext.SerieGenders.Include(x => x.Gender).Where(s => s.IdSerie == idSerie).ToList();
            return gender;
        }
    }
}
