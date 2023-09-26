using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.SerieGenderViewModel;
using AutoMapper;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SerieGenderService : ISerieGenderService
    {
        private readonly ISeriesGendersRepository _serieGenderRepository;
        private readonly IMapper _mapper;

        public SerieGenderService(ISeriesGendersRepository serieGenderRepository, IMapper mapper)
        {
            _serieGenderRepository = serieGenderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(SerieGenderSaveViewModel vm)
        {
            var serieGender = _mapper.Map<SerieGender>(vm);
            await _serieGenderRepository.AddAsync(serieGender);
        }

        public Task DeleteAsync(SerieGenderSaveViewModel vm)
        {
            throw new NotImplementedException();
        }

        public Task<List<SerieGenderSaveViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SerieGenderSaveViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SerieGenderSaveViewModel vm)
        {
            throw new NotImplementedException();
        }
    }
}
