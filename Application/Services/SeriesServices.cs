using Application.Interfaces.Generic;
using Application.ViewModels;
using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SeriesServices
    {
        public readonly IBaseRepository<Series> _repository;
        public readonly IMapper _mapper;

        public SeriesServices(IBaseRepository<Series> Repository, IMapper mapper)
        {
            _repository = Repository;
            _mapper = mapper;
        }

        public async Task<List<SeriesViewModel>>GetAllViewModel()
        {
            var seriesList = await _repository.GetAll();
            var series = seriesList.Select(_mapper.Map<SeriesViewModel>).ToList();
            return series;
        }
    }
}
