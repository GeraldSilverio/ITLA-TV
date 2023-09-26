using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Database.Models;

namespace Application.Services
{
    public class SeriesServices:ISeriesServices
    {
        private readonly ISeriesRepository _series;
        private readonly IMapper _mapper;
        private readonly ISerieGenderService _serieGenderService;

        public SeriesServices(IMapper mapper, ISeriesRepository series,ISerieGenderService serieGenderService)
        {
            _mapper = mapper;
            _series = series;
            _serieGenderService = serieGenderService;
        }
        public async Task<SeriesViewModel> GetByIdAsync(int id)
        {
            var serie = await _series.GetByIdAsync(id);
            var serieView = _mapper.Map<SeriesViewModel>(serie);
            return serieView;
        }

        public async Task<List<SeriesViewModel>> GetAllAsync()
        {
            var series = await _series.GetAllWithIncludeAsync(new List<string> { "ProductionCompain" });
            var seriesList = series.Select(_mapper.Map<SeriesViewModel>).ToList();
            return seriesList;
        }

        public async Task<List<SeriesViewModel>> GetByFiltersAsync(SerieFilterViewModel serieFilter)
        {
            var series = await _series.GetAllWithIncludeAsync(new List<string> { "ProductionCompain" });
            var seriesList = series.Select(_mapper.Map<SeriesViewModel>).ToList();
          
            

            if (serieFilter.Id != 0)
            {
                seriesList = seriesList.Where(s => s.IdProduction == serieFilter.Id).ToList();
            }
            if (serieFilter.Name !=null)
            {
                seriesList = seriesList.Where(s => s.Name.ToLower() == serieFilter.Name.ToLower()).ToList();
            }

            return seriesList;
        }


        public async Task AddAsync(SeriesViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            serie.IdProduction = vm.IdProduction;
            serie.DateOfCreation = DateTime.Now;
            await _series.AddAsync(serie);

            var serieCreated = await _series.GetSerieByName(vm.Name);
            
                var serieGender = new SerieGenderSaveViewModel()
                {
                    IdSerie = serieCreated.Id,
                    IdGender = vm.IdGender,
                };
                var serieGenderSecundary = new SerieGenderSaveViewModel()
                {
                    IdSerie = serieCreated.Id,
                    IdGender = vm.IdGenderSecundary,
                };

                await _serieGenderService.AddAsync(serieGender);
                await _serieGenderService.AddAsync(serieGenderSecundary);
            
        }

        public async Task UpdateAsync(SeriesViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            serie.DateOfEdit = DateTime.Now;
            await _series.UpdateAsync(serie);
        }

        public async Task DeleteAsync(SeriesViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            await _series.DeleteAsync(serie);
        }
    }
}
