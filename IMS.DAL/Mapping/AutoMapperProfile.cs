using AutoMapper;
using IMS.BLL.DTOs.Auth;
using IMS.DAL.Entities;

namespace IMS.DAL.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, AdminUserDTO>();
        }
    }
}