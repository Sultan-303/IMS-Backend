using AutoMapper;
using IMS.Common.DTOs.Auth;
using IMS.Common.Entities;

namespace IMS.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}