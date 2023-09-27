using Application.Interfaces.Generic;
using Database.Models;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesGendersRepository : IBaseRepository<SerieGender>
    {
        List<SerieGender> GetSerieGendersByIdSerie(int idSerie);
    }
}
