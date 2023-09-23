using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using AutoMapper;
using Database.Models;

namespace Application.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IMapper _mapper;

        public ProductionService(IProductionRepository productionRepository, IMapper mapper)
        {
            _productionRepository = productionRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductionSaveViewModel vm)
        {
            var production = _mapper.Map<ProductionCompain>(vm);
            production.DateOfCreation = DateTime.Now;
            await _productionRepository.AddAsync(production);
        }

        public async Task DeleteAsync(ProductionSaveViewModel vm)
        {
            var production = _mapper.Map<ProductionCompain>(vm);
            await _productionRepository.DeleteAsync(production);
        }

        public async Task<List<ProductionViewModel>> GetAllAsync()
        {
            var productions = await _productionRepository.GetAllAsync();
            var productionsList = productions.Select(_mapper.Map<ProductionViewModel>).ToList();
            return productionsList;
        }

        public async Task<ProductionSaveViewModel> GetByIdAsync(int id)
        {
            var production = await _productionRepository.GetByIdAsync(id);
            var saveProduction = _mapper.Map<ProductionSaveViewModel>(production);
            return saveProduction;
        }

        public async Task UpdateAsync(ProductionSaveViewModel vm)
        {
            var production = _mapper.Map<ProductionCompain>(vm);
            production.DateOfEdit = DateTime.Now;
            await _productionRepository.UpdateAsync(production);
        }
    }
}
