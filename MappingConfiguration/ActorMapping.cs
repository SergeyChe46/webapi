using AutoMapper;
using webapi.Models;

namespace webapi.MappingConfiguration
{
    public class ActorMapping
    {
        public static Mapper InitializeMapping()
        {
            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ActorViewModel, Actor>()
                    .ForMember(dst => dst.FullName, act => act.MapFrom(src => src.Name));
                });
            Mapper mapper = new Mapper(config);
            return mapper;
        }
    }
}
