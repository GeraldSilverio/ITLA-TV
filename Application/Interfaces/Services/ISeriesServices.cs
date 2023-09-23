using Application.ViewModels.SeriesViewModel;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesServices
    {
        Task<SeriesViewModel> GetByIdAsync(int id);
        Task<List<SeriesViewModel>> GetAllAsync();
        Task AddAsync(SeriesViewModel vm);
        Task UpdateAsync(SeriesViewModel vm);
        Task DeleteAsync(SeriesViewModel vm);

    }
}


