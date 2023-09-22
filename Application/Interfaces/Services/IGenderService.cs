using Application.ViewModels.GendersViewModel;

namespace Application.Interfaces.Repositories
{
    public interface IGenderService
    {
        Task<List<GenderViewModel>>GetAll();
        Task AddAsync(GenderAddViewModel vm);
        Task UpdateAsync(GenderAddViewModel vm);
        Task DeleteAsync(int id);
        
    }

}

