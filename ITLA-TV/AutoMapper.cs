using Application.ViewModels;
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
        }
    }
}
