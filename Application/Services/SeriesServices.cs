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
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;
        private readonly ISerieGenderService _serieGenderService;
        private readonly IGenderService _genderService;
        private readonly ISeriesGendersRepository _seriesGendersRepository;

        public SeriesServices(IMapper mapper, ISeriesRepository series, ISerieGenderService serieGenderService, IGenderService genderService, ISeriesGendersRepository seriesGendersRepository)
        {
            _mapper = mapper;
            _seriesRepository = series;
            _serieGenderService = serieGenderService;
            _genderService = genderService;
            _seriesGendersRepository = seriesGendersRepository;
        }
        public async Task<SeriesViewModel> GetByIdAsync(int id)
        {
            var serie = await _seriesRepository.GetByIdAsync(id);
            var serieView = _mapper.Map<SeriesViewModel>(serie);
            return serieView;
        }

        public async Task<List<SeriesViewModel>> GetAllAsync()
        {
            var series = await _seriesRepository.GetAllWithIncludeAsync(new List<string> { "ProductionCompain"});
            var seriesList = series.Select(_mapper.Map<SeriesViewModel>).ToList();
            List<Genders> gender = new();
            

            foreach(var serie in seriesList)
            {
                gender = _seriesRepository.GenderBySerie(serie.Id);
                serie.IdGender = gender[0].Id;
                serie.IdGenderSecundary = gender[1].Id;
                serie.PrimaryGender = gender[0].Name;
                serie.SecundaryGender = gender[1].Name;
            }
            
            return seriesList;
        }

        public async Task<List<SeriesViewModel>> GetByFiltersAsync(SerieFilterViewModel serieFilter)
        {
            var series = await GetAllAsync();
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


        public async Task AddAsync(SeriesSaveViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            serie.IdProduction = vm.IdProduction;
            serie.DateOfCreation = DateTime.Now;
            await _seriesRepository.AddAsync(serie);
            await _serieGenderService.AddAsync(vm);
        }

        public async Task UpdateAsync(SeriesSaveViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            serie.DateOfEdit = DateTime.Now;
            await _seriesRepository.UpdateAsync(serie);
        }

        public async Task DeleteAsync(SeriesSaveViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            await _seriesRepository.DeleteAsync(serie);
        }
    }
}
