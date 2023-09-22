using Application.ViewModels.GendersViewModel;
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
            CreateMap<Series, SeriesViewModel>();
            CreateMap<Genders,GenderViewModel>();
            CreateMap<GenderAddViewModel,Genders>();

        }
    }
}
