using Application.ViewModels.GendersViewModel;
using Application.ViewModels.SerieGenderViewModel;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ISerieGenderService
    {
        Task<SerieGenderSaveViewModel> GetByIdAsync(int id);
        Task<List<SerieGenderSaveViewModel>> GetAllAsync();
        Task AddAsync(SerieGenderSaveViewModel vm);
        Task UpdateAsync(SerieGenderSaveViewModel vm);
        Task DeleteAsync(SerieGenderSaveViewModel vm);
    }
}
