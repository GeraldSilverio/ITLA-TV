using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using Database.Models;

namespace Application.Interfaces.Services
{
    public interface ISerieGenderService
    {
        Task<List<SerieGenderSaveViewModel>> GetAllAsync();
        Task AddAsync(SeriesSaveViewModel vm);
        Task UpdateAsync(SerieGenderSaveViewModel vm);
        Task DeleteAsync(SerieGenderSaveViewModel vm);
    }
}
