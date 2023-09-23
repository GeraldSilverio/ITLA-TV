using Application.ViewModels.ProductionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IProductionService
    {
        Task<ProductionSaveViewModel> GetByIdAsync(int id);
        Task<List<ProductionViewModel>> GetAllAsync();
        Task AddAsync(ProductionSaveViewModel vm);
        Task UpdateAsync(ProductionSaveViewModel vm);
        Task DeleteAsync(ProductionSaveViewModel vm);
    }
}
