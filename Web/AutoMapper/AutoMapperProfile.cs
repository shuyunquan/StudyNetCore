using AutoMapper;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace Web.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Movie
            //CreateMap<Movie, MovieViewModel>(); 字段完全一致就可以这样写
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Info, opt => opt.MapFrom(src => src.Title + src.Genre))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ReleaseDate));

            #endregion
        }
    }
}
