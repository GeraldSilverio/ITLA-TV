using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.ProductionViewModel;
using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class SeriesServices:ISeriesServices
    {
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;
        private readonly ISerieGenderService _serieGenderService;
        public SeriesServices(IMapper mapper, ISeriesRepository series, ISerieGenderService serieGenderService)
        {
            _mapper = mapper;
            _seriesRepository = series;
            _serieGenderService = serieGenderService;
        }
        public async Task<SeriesSaveViewModel> GetByIdAsync(int id)
        {
            List<Genders> gender = _seriesRepository.GenderBySerie(id);
            var serie = await _seriesRepository.GetByIdAsync(id);
            var serieView = _mapper.Map<SeriesSaveViewModel>(serie);

            if(gender.Count == 2)
            {
                serieView.IdGender = gender[0].Id;
                serieView.IdGenderSecundary = gender[1].Id;
            }
            else if(gender.Count ==1)
            {
                serieView.IdGender = gender[0].Id;
            }
            else
            {
                return serieView;
            }

            
            return serieView;
        }

        public async Task<List<SeriesViewModel>> GetAllAsync()
        {
            List<Genders> gender = new();
            var series = await _seriesRepository.GetAllWithIncludeAsync(new List<string> { "ProductionCompain"});
            var seriesList = series.Select(x => new SeriesViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                ImagenUrl = x.ImagenUrl,
                VideoUrl = x.VideoUrl,
                IdProduction = x.ProductionCompain.Id,
                ProductionName = x.ProductionCompain.Name
            }).ToList();

            foreach(var serie in seriesList)
            {
                gender = _seriesRepository.GenderBySerie(serie.Id);

                if(gender.Count == 2)
                {
                    serie.IdGender = gender[0].Id;
                    serie.IdGenderSecundary = gender[1].Id;
                    serie.PrimaryGender = gender[0].Name;
                    serie.SecundaryGender = gender[1].Name;

                }
                else if(gender.Count == 1)
                {
                    serie.IdGender = gender[0].Id;
                    serie.SecundaryGender = gender[0].Name;
                }
                else
                {
                    return seriesList;
                }

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
            await _serieGenderService.UpdateAsync(vm);
        }

        public async Task DeleteAsync(SeriesSaveViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            await _seriesRepository.DeleteAsync(serie);
        }

        public bool IsNameCreated(string name, int idSerie)
        {
            return _seriesRepository.IsNameCreated(name, idSerie);
        }

    }
}
