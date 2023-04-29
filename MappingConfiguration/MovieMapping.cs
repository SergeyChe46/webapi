using AutoMapper;
using webapi.Models;

namespace webapi.MappingConfiguration
{
    public class MovieMapping
    {
        public static Mapper IntializeMovieMapper()
        {
            var config = new MapperConfiguration(
                cfg => {
                    cfg.CreateMap<MovieViewModel, Movie>()
                    .ForMember(dst => dst.Title, act => act.MapFrom(src => src.Title ?? ""))
                    .ForMember(dst => dst.Director, act => act.MapFrom(src => src.Director ?? ""))
                    .ForMember(dst => dst.ReleaseDate, act => act.MapFrom(src => src.ReleaseDate));
                });
            Mapper mapper = new Mapper(config);
            return mapper;
        }
    }
}
