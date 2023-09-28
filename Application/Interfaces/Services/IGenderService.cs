using Application.ViewModels.GendersViewModel;

namespace Application.Interfaces.Repositories
{
    public interface IGenderService
    {
        Task<SaveGenderViewModel>GetByIdAsync(int id);
        Task<List<GenderViewModel>>GetAllAsync();
        Task AddAsync(SaveGenderViewModel vm);
        Task UpdateAsync(SaveGenderViewModel vm);
        Task DeleteAsync(SaveGenderViewModel vm);
        bool IsNameCreated(string name, int idSerie);

    }
}

