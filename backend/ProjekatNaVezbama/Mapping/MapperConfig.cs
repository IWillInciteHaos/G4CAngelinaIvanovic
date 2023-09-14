using AutoMapper;
using ProjekatNaVezbama.DTO;
using ProjekatNaVezbama.Model;

namespace ProjekatNaVezbama.Mapping
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<User, UserOutDTO>().ReverseMap();
        }

    }
}
