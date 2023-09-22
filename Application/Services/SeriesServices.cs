using Application.Interfaces.Repositories;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;


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

        public async Task<List<SeriesViewModel>> GetAllViewModel()
        {
            var seriesList = await _series.GetAll();
            var series =  seriesList.Select(_mapper.Map<SeriesViewModel>).ToList();
            return series;
        }
    }
}
