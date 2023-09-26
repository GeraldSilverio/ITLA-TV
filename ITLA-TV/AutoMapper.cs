using Application.ViewModels.GendersViewModel;
using Application.ViewModels.ProductionViewModel;
using Application.ViewModels.SerieGenderViewModel;
using Application.ViewModels.SeriesViewModel;
using AutoMapper;
using Database.Models;

namespace ITLA_TV
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<SeriesViewModel, Series>();
            CreateMap<Series, SeriesViewModel>().ForMember(dest => dest.IdProduction, opt => opt.MapFrom(src => src.ProductionCompain.Id))
                .ForMember(dest => dest.ProductionName, opt => opt.MapFrom(src => src.ProductionCompain.Name));

            CreateMap<SerieGenderSaveViewModel, SerieGender>();

            CreateMap<Genders,GenderViewModel>();
            CreateMap<SaveGenderViewModel,Genders>();
            CreateMap<Genders,SaveGenderViewModel>();

            CreateMap<ProductionCompain, ProductionViewModel>();
            CreateMap<ProductionSaveViewModel, ProductionCompain>();
            CreateMap<ProductionCompain, ProductionSaveViewModel>();

        }
    }
}
