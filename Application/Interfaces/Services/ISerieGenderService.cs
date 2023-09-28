using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using Database.Models;

namespace Application.Interfaces.Services
{
    public interface ISerieGenderService
    {
        Task AddAsync(SeriesSaveViewModel vm);
        Task UpdateAsync(SeriesSaveViewModel vm);
    }
}
