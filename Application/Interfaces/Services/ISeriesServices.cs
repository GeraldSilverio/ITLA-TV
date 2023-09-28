using Application.ViewModels.SeriesViewModel;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesServices
    {
        Task<SeriesSaveViewModel> GetByIdAsync(int id);
        Task<List<SeriesViewModel>> GetAllAsync();
        Task AddAsync(SeriesSaveViewModel vm);
        Task UpdateAsync(SeriesSaveViewModel vm);
        Task DeleteAsync(SeriesSaveViewModel vm);
        Task<List<SeriesViewModel>> GetByFiltersAsync(SerieFilterViewModel serieFilter);

    }
}


