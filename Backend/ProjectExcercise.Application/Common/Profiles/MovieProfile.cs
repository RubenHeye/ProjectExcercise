using AutoMapper;
using ProjectExcercise.Application.Common.Movies.Dtos;
using ProjectExcersice.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectExcercise.Application.Common.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDetailsDto>();
            CreateMap<Movie, MovieDto>().ForMember(x => x.PictureUri, options =>
            {
                options.MapFrom(y => y.Picture);
            });
        }
    }
}
