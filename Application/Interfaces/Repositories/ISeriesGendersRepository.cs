using Application.Interfaces.Generic;
using Database.Models;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesGendersRepository : IBaseRepository<SerieGender>
    {
        Task ClearSerieGender(int idSerie);
    }
}
