using Application.Interfaces.Repositories;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Database.Models;

namespace Application.Services
{
    public class SeriesServices:ISeriesServices
    {
        private readonly ISeriesRepository _series;
        public readonly IMapper _mapper;
        public SeriesServices(IMapper mapper, ISeriesRepository series)
        {
            _mapper = mapper;
            _series = series;
        }
        public async Task<SeriesViewModel> GetByIdAsync(int id)
        {
            var serie = await _series.GetByIdAsync(id);
            var serieView = _mapper.Map<SeriesViewModel>(serie);
            return serieView;
        }

        public async Task<List<SeriesViewModel>> GetAllAsync()
        {
            var seriesList = await _series.GetAllAsync();
            var series = seriesList.Select(_mapper.Map<SeriesViewModel>).ToList();
            return series;
        }

        public async Task AddAsync(SeriesViewModel vm)
        {
            var serie = _mapper.Map<Series>(vm);
            serie.DateOfCreation = DateTime.Now;
            await _series.AddAsync(serie);
        }

        public Task UpdateAsync(SeriesViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(SeriesViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
