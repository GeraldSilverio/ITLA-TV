using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Database.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly ISeriesRepository _seriesServices;

        public SerieGenderService(ISeriesGendersRepository serieGenderRepository, IMapper mapper, ISeriesRepository seriesServices)
        {
            _serieGenderRepository = serieGenderRepository;
            _mapper = mapper;
            _seriesServices = seriesServices;
        }

        public async Task AddAsync(SeriesSaveViewModel vm)
        {
            var serieCreated = await _seriesServices.GetSerieByName(vm.Name);

            var serieGender = new SerieGender()
            {
                IdSerie = serieCreated.Id,
                IdGender = vm.IdGender,
                DateOfCreation = DateTime.Now
            };
            var serieGenderSecundary = new SerieGender()
            {
                IdSerie = serieCreated.Id,
                IdGender = vm.IdGenderSecundary,
                DateOfCreation = DateTime.Now
            };

            await _serieGenderRepository.AddAsync(serieGender);
            await _serieGenderRepository.AddAsync(serieGenderSecundary);
        }

        public async Task UpdateAsync(SeriesSaveViewModel vm)
        {
            await _serieGenderRepository.ClearSerieGender(vm.Id);


            var serieGender = new SerieGender()
            {
                IdSerie = vm.Id,
                IdGender = vm.IdGender,
                DateOfEdit = DateTime.Now
            };
            var serieGenderSecundary = new SerieGender()
            {
                IdSerie = vm.Id,
                IdGender = vm.IdGenderSecundary,
                DateOfEdit = DateTime.Now
            };

            await _serieGenderRepository.AddAsync(serieGender);
            await _serieGenderRepository.AddAsync(serieGenderSecundary);
        }
    }
}
