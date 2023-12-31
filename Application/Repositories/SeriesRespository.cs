﻿using Application.Interfaces.Repositories;
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

        public List<Genders> GenderBySerie(int idSerie)
        {
            return _dbContext.SerieGenders.Where(x => x.IdSerie == idSerie)
                .Select(x => new Genders
            {
                Id = x.Gender.Id,
                Name = x.Gender.Name
            }).ToList();  
        }

        public async Task<Series> GetSerieByName(string name)
        {
            var serie = await _dbContext.Series.FirstOrDefaultAsync(s => s.Name == name);

            return serie;
        }

        public bool IsNameCreated(string name, int idSerie)
        {
            return _dbContext.Series.Any(s => s.Name == name && s.Id != idSerie);
        }

    }
}
