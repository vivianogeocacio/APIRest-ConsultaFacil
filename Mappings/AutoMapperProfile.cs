using AutoMapper;
using apirest.Models;

namespace UserService.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Usuario, RegisterDto>().ReverseMap();
        }
    }
}