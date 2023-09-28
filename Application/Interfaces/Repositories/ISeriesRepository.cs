
using Application.Interfaces.Generic;
using Database.Models;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesRepository : IBaseRepository<Series>
    {
        Task<Series> GetSerieByName(string name);
        List<Genders> GenderBySerie(int idSerie);
        bool IsNameCreated(string name, int idSerie);

    }
}


