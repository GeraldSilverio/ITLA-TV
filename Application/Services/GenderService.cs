using Application.Interfaces.Repositories;
using Application.ViewModels.GendersViewModel;
using AutoMapper;
using Database.Models;

namespace Application.Services;

public class GenderService : IGenderService
{
    private readonly IGendersRepository _genderRepository;
    private readonly IMapper _mapper;

    public GenderService(IGendersRepository genderRepository, IMapper mapper)
    {
        _genderRepository = genderRepository;
        _mapper = mapper;
    }

    public async Task AddAsync(SaveGenderViewModel vm)
    {
        var gender = _mapper.Map<Genders>(vm);
        gender.DateOfCreation = DateTime.Now;
        await _genderRepository.Add(gender);
    }

    public async Task DeleteAsync(int id)
    {
        var gender = await _genderRepository.GetById(1);
        await _genderRepository.Delete(gender);
    }

    public async Task<List<GenderViewModel>> GetAll()
    {
        var gendersList = await _genderRepository.GetAll();
        var genders = gendersList.Select(_mapper.Map<GenderViewModel>).ToList();
        return genders;
    }

    public async Task UpdateAsync(SaveGenderViewModel vm)
    {
        var gender = _mapper.Map<Genders>(vm);
        await _genderRepository.Update(gender);
    }
}
