using Application.ViewModels.SeriesViewModel;

namespace Application.Interfaces.Repositories
{
    public interface ISeriesServices
    {
        Task<List<SeriesViewModel>> GetAllViewModel();

    }
}


