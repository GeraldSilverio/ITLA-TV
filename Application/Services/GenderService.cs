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
        await _genderRepository.AddAsync(gender);
    }

    public async Task DeleteAsync(SaveGenderViewModel vm)
    {
        var gender = _mapper.Map<Genders>(vm);
        await _genderRepository.DeleteAsync(gender);
    }

    public async Task<List<GenderViewModel>> GetAllAsync()
    {
        var gendersList = await _genderRepository.GetAllAsync();
        var genders = gendersList.Select(_mapper.Map<GenderViewModel>).ToList();
        return genders;
    }

    public async Task<SaveGenderViewModel> GetByIdAsync(int id)
    {
        var gender = await _genderRepository.GetByIdAsync(id);
        var saveGender = _mapper.Map<SaveGenderViewModel>(gender);
        return saveGender;
    }

    public bool IsNameCreated(string name, int idSerie)
    {
        return _genderRepository.IsNameCreated(name, idSerie);
    }

    public async Task UpdateAsync(SaveGenderViewModel vm)
    {
        var gender = _mapper.Map<Genders>(vm);
        gender.DateOfEdit = DateTime.Now;
        await _genderRepository.UpdateAsync(gender);
    }
}
