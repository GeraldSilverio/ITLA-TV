using Application.ViewModels.GendersViewModel;

namespace Application.Interfaces.Repositories
{
    public interface IGenderService
    {
        Task<List<GenderViewModel>>GetAll();
        Task AddAsync(SaveGenderViewModel vm);
        Task UpdateAsync(SaveGenderViewModel vm);
        Task DeleteAsync(int id);
        
    }

}

